import { useState, useEffect, createContext, useContext, useCallback } from "react";

// ─── CONFIG ────────────────────────────────────────────────────────────────
const API = "http://localhost:5000/api";

// ─── AUTH CONTEXT ──────────────────────────────────────────────────────────
const AuthCtx = createContext(null);
function useAuth() { return useContext(AuthCtx); }

function AuthProvider({ children }) {
  const [token, setToken] = useState(() => localStorage.getItem("kira_token"));
  const [user, setUser]   = useState(() => {
    try { return JSON.parse(localStorage.getItem("kira_user") || "null"); } catch { return null; }
  });

  const login = async (email, password) => {
    const res = await fetch(`${API}/Auth/login`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ email, password })
    });
    if (!res.ok) throw new Error("Giriş başarısız");
    const data = await res.json();
    setToken(data.access_token);
    setUser(data.user);
    localStorage.setItem("kira_token", data.access_token);
    localStorage.setItem("kira_user", JSON.stringify(data.user));
    return data;
  };

  const logout = () => {
    setToken(null); setUser(null);
    localStorage.removeItem("kira_token");
    localStorage.removeItem("kira_user");
  };

  const authFetch = useCallback(async (url, opts = {}) => {
    const res = await fetch(`${API}${url}`, {
      ...opts,
      headers: { "Content-Type": "application/json", Authorization: `Bearer ${token}`, ...opts.headers }
    });
    if (res.status === 401) { logout(); throw new Error("Oturum süresi doldu"); }
    return res;
  }, [token]);

  return <AuthCtx.Provider value={{ token, user, login, logout, authFetch }}>{children}</AuthCtx.Provider>;
}

// ─── TOAST ────────────────────────────────────────────────────────────────
const ToastCtx = createContext(null);
function ToastProvider({ children }) {
  const [toasts, setToasts] = useState([]);
  const add = (msg, type = "info") => {
    const id = Date.now();
    setToasts(t => [...t, { id, msg, type }]);
    setTimeout(() => setToasts(t => t.filter(x => x.id !== id)), 3500);
  };
  return (
    <ToastCtx.Provider value={{ success: m => add(m, "success"), error: m => add(m, "error"), info: m => add(m, "info") }}>
      {children}
      <div style={{ position: "fixed", bottom: 24, right: 24, zIndex: 9999, display: "flex", flexDirection: "column", gap: 8 }}>
        {toasts.map(t => (
          <div key={t.id} style={{
            padding: "12px 20px", borderRadius: 10, fontSize: 14, fontWeight: 500,
            background: t.type === "success" ? "#10b981" : t.type === "error" ? "#ef4444" : "#3b82f6",
            color: "#fff", boxShadow: "0 4px 20px rgba(0,0,0,0.2)",
            animation: "slideIn 0.3s ease"
          }}>{t.msg}</div>
        ))}
      </div>
    </ToastCtx.Provider>
  );
}
function useToast() { return useContext(ToastCtx); }

// ─── STYLES ───────────────────────────────────────────────────────────────
const CSS = `
  @import url('https://fonts.googleapis.com/css2?family=Playfair+Display:wght@700&family=DM+Sans:wght@300;400;500;600&display=swap');
  *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }
  :root {
    --bg: #0d1117;
    --surface: #161b22;
    --surface2: #1e2530;
    --border: #30363d;
    --accent: #f0a500;
    --accent2: #ff6b35;
    --text: #e6edf3;
    --muted: #8b949e;
    --success: #10b981;
    --danger: #ef4444;
    --radius: 12px;
    --shadow: 0 4px 24px rgba(0,0,0,0.4);
  }
  body { font-family: 'DM Sans', sans-serif; background: var(--bg); color: var(--text); min-height: 100vh; }
  input, select, textarea {
    background: var(--surface2); border: 1px solid var(--border); color: var(--text);
    border-radius: 8px; padding: 10px 14px; font-family: inherit; font-size: 14px; width: 100%;
    outline: none; transition: border-color 0.2s;
  }
  input:focus, select:focus, textarea:focus { border-color: var(--accent); }
  button { cursor: pointer; font-family: inherit; }
  table { border-collapse: collapse; width: 100%; }
  th, td { padding: 12px 16px; text-align: left; border-bottom: 1px solid var(--border); }
  th { color: var(--muted); font-size: 12px; text-transform: uppercase; letter-spacing: 0.05em; }
  tr:hover td { background: var(--surface2); }
  @keyframes slideIn { from { transform: translateX(60px); opacity: 0; } to { transform: translateX(0); opacity: 1; } }
  @keyframes fadeUp { from { transform: translateY(20px); opacity: 0; } to { transform: translateY(0); opacity: 1; } }
  ::-webkit-scrollbar { width: 6px; } ::-webkit-scrollbar-track { background: var(--bg); }
  ::-webkit-scrollbar-thumb { background: var(--border); border-radius: 3px; }
`;

// ─── COMPONENTS ───────────────────────────────────────────────────────────
function Btn({ children, onClick, variant = "primary", size = "md", disabled, style }) {
  const styles = {
    primary: { background: "linear-gradient(135deg, #f0a500, #ff6b35)", color: "#000", fontWeight: 600 },
    secondary: { background: "var(--surface2)", color: "var(--text)", border: "1px solid var(--border)" },
    danger: { background: "#ef4444", color: "#fff" },
    ghost: { background: "transparent", color: "var(--muted)", border: "1px solid var(--border)" },
  };
  const sizes = { sm: { padding: "6px 14px", fontSize: 13 }, md: { padding: "10px 20px", fontSize: 14 }, lg: { padding: "14px 28px", fontSize: 16 } };
  return (
    <button onClick={onClick} disabled={disabled} style={{
      borderRadius: 8, border: "none", transition: "all 0.2s", opacity: disabled ? 0.5 : 1,
      ...styles[variant], ...sizes[size], ...style
    }}>{children}</button>
  );
}

function Card({ children, style }) {
  return <div style={{ background: "var(--surface)", borderRadius: "var(--radius)", border: "1px solid var(--border)", padding: 24, ...style }}>{children}</div>;
}

function Badge({ children, color = "accent" }) {
  const colors = {
    accent: { background: "rgba(240,165,0,0.15)", color: "#f0a500" },
    success: { background: "rgba(16,185,129,0.15)", color: "#10b981" },
    danger: { background: "rgba(239,68,68,0.15)", color: "#ef4444" },
    muted: { background: "rgba(139,148,158,0.15)", color: "#8b949e" },
  };
  return <span style={{ padding: "4px 10px", borderRadius: 20, fontSize: 12, fontWeight: 600, ...colors[color] }}>{children}</span>;
}

function Modal({ open, onClose, title, children, width = 480 }) {
  if (!open) return null;
  return (
    <div onClick={onClose} style={{ position: "fixed", inset: 0, background: "rgba(0,0,0,0.7)", zIndex: 1000, display: "flex", alignItems: "center", justifyContent: "center" }}>
      <div onClick={e => e.stopPropagation()} style={{ background: "var(--surface)", borderRadius: 16, border: "1px solid var(--border)", padding: 32, width, maxWidth: "90vw", animation: "fadeUp 0.25s ease", maxHeight: "90vh", overflowY: "auto" }}>
        <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 24 }}>
          <h3 style={{ fontFamily: "'Playfair Display', serif", fontSize: 20 }}>{title}</h3>
          <button onClick={onClose} style={{ background: "none", border: "none", color: "var(--muted)", fontSize: 24, lineHeight: 1, cursor: "pointer" }}>×</button>
        </div>
        {children}
      </div>
    </div>
  );
}

function Field({ label, children }) {
  return <div style={{ marginBottom: 16 }}><label style={{ display: "block", fontSize: 13, color: "var(--muted)", marginBottom: 6 }}>{label}</label>{children}</div>;
}

function EmptyState({ icon, msg }) {
  return (
    <div style={{ textAlign: "center", padding: "60px 0", color: "var(--muted)" }}>
      <div style={{ fontSize: 48, marginBottom: 12 }}>{icon}</div>
      <p style={{ fontSize: 15 }}>{msg}</p>
    </div>
  );
}

function Loader() {
  return <div style={{ display: "flex", justifyContent: "center", padding: 60 }}>
    <div style={{ width: 36, height: 36, border: "3px solid var(--border)", borderTopColor: "var(--accent)", borderRadius: "50%", animation: "spin 0.8s linear infinite" }} />
    <style>{`@keyframes spin{to{transform:rotate(360deg)}}`}</style>
  </div>;
}

// ─── LOGIN PAGE ────────────────────────────────────────────────────────────
function LoginPage() {
  const { login } = useAuth();
  const toast = useToast();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);

  const handleLogin = async () => {
    if (!email || !password) { toast.error("E-posta ve şifre girin"); return; }
    setLoading(true);
    try { await login(email, password); toast.success("Hoş geldiniz!"); }
    catch (e) { toast.error(e.message); }
    finally { setLoading(false); }
  };

  return (
    <div style={{ minHeight: "100vh", display: "flex", alignItems: "center", justifyContent: "center", background: "radial-gradient(ellipse at 50% 0%, rgba(240,165,0,0.08) 0%, var(--bg) 70%)" }}>
      <div style={{ width: 420, animation: "fadeUp 0.4s ease" }}>
        <div style={{ textAlign: "center", marginBottom: 40 }}>
          <div style={{ fontSize: 48, marginBottom: 8 }}>🏢</div>
          <h1 style={{ fontFamily: "'Playfair Display', serif", fontSize: 32, background: "linear-gradient(135deg, #f0a500, #ff6b35)", WebkitBackgroundClip: "text", WebkitTextFillColor: "transparent" }}>KiraYönetimi</h1>
          <p style={{ color: "var(--muted)", marginTop: 8 }}>Apartman yönetim paneline giriş yapın</p>
        </div>
        <Card>
          <Field label="E-posta">
            <input type="email" value={email} onChange={e => setEmail(e.target.value)} placeholder="ornek@mail.com" onKeyDown={e => e.key === "Enter" && handleLogin()} />
          </Field>
          <Field label="Şifre">
            <input type="password" value={password} onChange={e => setPassword(e.target.value)} placeholder="••••••••" onKeyDown={e => e.key === "Enter" && handleLogin()} />
          </Field>
          <Btn onClick={handleLogin} disabled={loading} style={{ width: "100%", marginTop: 8 }}>
            {loading ? "Giriş yapılıyor..." : "Giriş Yap"}
          </Btn>
        </Card>
        <p style={{ textAlign: "center", color: "var(--muted)", marginTop: 20, fontSize: 13 }}>
          Demo: <code style={{ background: "var(--surface2)", padding: "2px 6px", borderRadius: 4 }}>admin@demo.com / 123456</code>
        </p>
      </div>
    </div>
  );
}

// ─── SIDEBAR ──────────────────────────────────────────────────────────────
const NAV = [
  { id: "dashboard", label: "Dashboard", icon: "📊" },
  { id: "aparts", label: "Daireler", icon: "🏠" },
  { id: "users", label: "Kiracılar", icon: "👥" },
  { id: "invoices", label: "Faturalar", icon: "📄" },
  { id: "payments", label: "Ödemeler", icon: "💳" },
  { id: "messages", label: "Mesajlar", icon: "💬" },
];

function Sidebar({ page, setPage }) {
  const { user, logout } = useAuth();
  return (
    <div style={{ width: 240, background: "var(--surface)", borderRight: "1px solid var(--border)", display: "flex", flexDirection: "column", height: "100vh", position: "sticky", top: 0 }}>
      <div style={{ padding: "24px 20px", borderBottom: "1px solid var(--border)" }}>
        <div style={{ display: "flex", alignItems: "center", gap: 10 }}>
          <span style={{ fontSize: 28 }}>🏢</span>
          <div>
            <div style={{ fontFamily: "'Playfair Display', serif", fontSize: 16, color: "var(--accent)" }}>KiraYönetimi</div>
            <div style={{ fontSize: 11, color: "var(--muted)" }}>Yönetim Paneli</div>
          </div>
        </div>
      </div>
      <nav style={{ flex: 1, padding: "12px 8px" }}>
        {NAV.map(n => (
          <button key={n.id} onClick={() => setPage(n.id)} style={{
            display: "flex", alignItems: "center", gap: 10, width: "100%", padding: "10px 12px",
            borderRadius: 8, border: "none", background: page === n.id ? "rgba(240,165,0,0.12)" : "transparent",
            color: page === n.id ? "var(--accent)" : "var(--muted)", fontWeight: page === n.id ? 600 : 400,
            fontSize: 14, cursor: "pointer", transition: "all 0.15s",
          }}>
            <span>{n.icon}</span>{n.label}
          </button>
        ))}
      </nav>
      <div style={{ padding: 16, borderTop: "1px solid var(--border)" }}>
        <div style={{ fontSize: 13, color: "var(--muted)", marginBottom: 4 }}>Giriş yapan</div>
        <div style={{ fontWeight: 600, marginBottom: 2 }}>{user?.name || "Kullanıcı"}</div>
        <div style={{ fontSize: 12, color: "var(--muted)", marginBottom: 12 }}>{user?.isAdmin ? "Yönetici" : "Kiracı"}</div>
        <Btn variant="ghost" size="sm" onClick={logout} style={{ width: "100%" }}>Çıkış Yap</Btn>
      </div>
    </div>
  );
}

// ─── DASHBOARD ────────────────────────────────────────────────────────────
function Dashboard() {
  const { authFetch } = useAuth();
  const [stats, setStats] = useState({ users: 0, aparts: 0, invoices: 0, paid: 0 });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    Promise.all([
      authFetch("/User").then(r => r.json()),
      authFetch("/Apart/GetAllAparts").then(r => r.json()),
      authFetch("/Invoice").then(r => r.json()),
    ]).then(([users, aparts, invoices]) => {
      const paid = invoices?.filter?.(i => i.invoiceStatus)?.length || 0;
      setStats({ users: users?.length || 0, aparts: aparts?.length || 0, invoices: invoices?.length || 0, paid });
    }).catch(() => {}).finally(() => setLoading(false));
  }, []);

  const cards = [
    { label: "Toplam Kiracı", value: stats.users, icon: "👥", color: "#3b82f6" },
    { label: "Toplam Daire", value: stats.aparts, icon: "🏠", color: "#f0a500" },
    { label: "Toplam Fatura", value: stats.invoices, icon: "📄", color: "#8b5cf6" },
    { label: "Ödenen Fatura", value: stats.paid, icon: "✅", color: "#10b981" },
  ];

  return (
    <div>
      <h2 style={{ fontFamily: "'Playfair Display', serif", fontSize: 28, marginBottom: 8 }}>Dashboard</h2>
      <p style={{ color: "var(--muted)", marginBottom: 32 }}>Sisteme genel bakış</p>
      {loading ? <Loader /> : (
        <div style={{ display: "grid", gridTemplateColumns: "repeat(4, 1fr)", gap: 20, marginBottom: 40 }}>
          {cards.map(c => (
            <Card key={c.label} style={{ animation: "fadeUp 0.4s ease" }}>
              <div style={{ display: "flex", justifyContent: "space-between", alignItems: "flex-start" }}>
                <div>
                  <div style={{ fontSize: 12, color: "var(--muted)", marginBottom: 8 }}>{c.label}</div>
                  <div style={{ fontSize: 36, fontWeight: 700, fontFamily: "'Playfair Display', serif", color: c.color }}>{c.value}</div>
                </div>
                <div style={{ fontSize: 32 }}>{c.icon}</div>
              </div>
            </Card>
          ))}
        </div>
      )}
      <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr", gap: 20 }}>
        <Card>
          <h3 style={{ marginBottom: 16, fontSize: 16 }}>📊 Doluluk Oranı</h3>
          {stats.aparts > 0 ? (
            <div>
              <div style={{ display: "flex", justifyContent: "space-between", marginBottom: 8, fontSize: 14 }}>
                <span>Dolu Daireler</span>
                <span style={{ color: "var(--accent)", fontWeight: 600 }}>{stats.users} / {stats.aparts}</span>
              </div>
              <div style={{ background: "var(--surface2)", borderRadius: 8, height: 12, overflow: "hidden" }}>
                <div style={{ height: "100%", width: `${Math.min(100, (stats.users / Math.max(stats.aparts, 1)) * 100)}%`, background: "linear-gradient(90deg, #f0a500, #ff6b35)", borderRadius: 8, transition: "width 0.8s ease" }} />
              </div>
            </div>
          ) : <p style={{ color: "var(--muted)", fontSize: 14 }}>Daire verisi yok</p>}
        </Card>
        <Card>
          <h3 style={{ marginBottom: 16, fontSize: 16 }}>💰 Fatura Durumu</h3>
          {stats.invoices > 0 ? (
            <div>
              <div style={{ display: "flex", justifyContent: "space-between", marginBottom: 8, fontSize: 14 }}>
                <span>Ödeme Oranı</span>
                <span style={{ color: "#10b981", fontWeight: 600 }}>{stats.paid} / {stats.invoices}</span>
              </div>
              <div style={{ background: "var(--surface2)", borderRadius: 8, height: 12, overflow: "hidden" }}>
                <div style={{ height: "100%", width: `${Math.min(100, (stats.paid / Math.max(stats.invoices, 1)) * 100)}%`, background: "linear-gradient(90deg, #10b981, #34d399)", borderRadius: 8 }} />
              </div>
            </div>
          ) : <p style={{ color: "var(--muted)", fontSize: 14 }}>Fatura verisi yok</p>}
        </Card>
      </div>
    </div>
  );
}

// ─── APARTS PAGE ──────────────────────────────────────────────────────────
function ApartsPage() {
  const { authFetch } = useAuth();
  const toast = useToast();
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [modal, setModal] = useState(false);
  const [form, setForm] = useState({ apartBlock: "", apartFloor: "", apartNo: "", apartStatus: false, apartOwnerOrTenant: false, apartTypeId: "", apartUserId: "" });

  const load = () => authFetch("/Apart/GetAllAparts").then(r => r.json()).then(setData).catch(() => {}).finally(() => setLoading(false));
  useEffect(() => { load(); }, []);

  const save = async () => {
    try {
      const res = await authFetch("/Apart/Create", { method: "POST", body: JSON.stringify({ ...form, apartBlock: +form.apartBlock, apartFloor: +form.apartFloor, apartNo: +form.apartNo, apartTypeId: +form.apartTypeId, apartUserId: +form.apartUserId }) });
      if (!res.ok) throw new Error();
      toast.success("Daire oluşturuldu");
      setModal(false);
      load();
    } catch { toast.error("Hata oluştu"); }
  };

  return (
    <div>
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 32 }}>
        <div>
          <h2 style={{ fontFamily: "'Playfair Display', serif", fontSize: 28, marginBottom: 4 }}>Daireler</h2>
          <p style={{ color: "var(--muted)" }}>{data.length} daire kayıtlı</p>
        </div>
        <Btn onClick={() => setModal(true)}>+ Yeni Daire</Btn>
      </div>
      {loading ? <Loader /> : data.length === 0 ? <EmptyState icon="🏠" msg="Henüz daire eklenmemiş" /> : (
        <Card style={{ padding: 0 }}>
          <table>
            <thead><tr><th>Blok</th><th>Kat</th><th>No</th><th>Tip</th><th>Durum</th><th>Mülkiyet</th></tr></thead>
            <tbody>
              {data.map((a, i) => (
                <tr key={a.pkId || i}>
                  <td style={{ fontWeight: 600 }}>{a.apartBlock}</td>
                  <td>{a.apartFloor}</td>
                  <td>{a.apartNo}</td>
                  <td>{a.apartTypeId || "-"}</td>
                  <td><Badge color={a.apartStatus ? "success" : "muted"}>{a.apartStatus ? "Dolu" : "Boş"}</Badge></td>
                  <td><Badge color={a.apartOwnerOrTenant ? "accent" : "muted"}>{a.apartOwnerOrTenant ? "Mal Sahibi" : "Kiracı"}</Badge></td>
                </tr>
              ))}
            </tbody>
          </table>
        </Card>
      )}
      <Modal open={modal} onClose={() => setModal(false)} title="Yeni Daire Ekle">
        <Field label="Blok"><input type="number" value={form.apartBlock} onChange={e => setForm(f => ({...f, apartBlock: e.target.value}))} placeholder="1" /></Field>
        <Field label="Kat"><input type="number" value={form.apartFloor} onChange={e => setForm(f => ({...f, apartFloor: e.target.value}))} placeholder="3" /></Field>
        <Field label="Daire No"><input type="number" value={form.apartNo} onChange={e => setForm(f => ({...f, apartNo: e.target.value}))} placeholder="12" /></Field>
        <Field label="Daire Tip ID"><input type="number" value={form.apartTypeId} onChange={e => setForm(f => ({...f, apartTypeId: e.target.value}))} placeholder="1" /></Field>
        <Field label="Kullanıcı ID"><input type="number" value={form.apartUserId} onChange={e => setForm(f => ({...f, apartUserId: e.target.value}))} placeholder="1" /></Field>
        <Field label="Durum">
          <select value={form.apartStatus} onChange={e => setForm(f => ({...f, apartStatus: e.target.value === "true"}))}>
            <option value="false">Boş</option>
            <option value="true">Dolu</option>
          </select>
        </Field>
        <Field label="Mülkiyet">
          <select value={form.apartOwnerOrTenant} onChange={e => setForm(f => ({...f, apartOwnerOrTenant: e.target.value === "true"}))}>
            <option value="false">Kiracı</option>
            <option value="true">Mal Sahibi</option>
          </select>
        </Field>
        <div style={{ display: "flex", gap: 10, justifyContent: "flex-end", marginTop: 8 }}>
          <Btn variant="ghost" onClick={() => setModal(false)}>İptal</Btn>
          <Btn onClick={save}>Kaydet</Btn>
        </div>
      </Modal>
    </div>
  );
}

// ─── USERS PAGE ───────────────────────────────────────────────────────────
function UsersPage() {
  const { authFetch } = useAuth();
  const toast = useToast();
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [modal, setModal] = useState(false);
  const [form, setForm] = useState({ fullName: "", email: "", password: "", phone: "", tcNo: "", plakaNo: "", role: false });

  const load = () => authFetch("/User").then(r => r.json()).then(d => setData(Array.isArray(d) ? d : [])).catch(() => setData([])).finally(() => setLoading(false));
  useEffect(() => { load(); }, []);

  const save = async () => {
    try {
      const res = await authFetch("/User", { method: "POST", body: JSON.stringify(form) });
      if (!res.ok) throw new Error();
      toast.success("Kullanıcı oluşturuldu");
      setModal(false);
      setForm({ fullName: "", email: "", password: "", phone: "", tcNo: "", plakaNo: "", role: false });
      load();
    } catch { toast.error("Hata oluştu"); }
  };

  return (
    <div>
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 32 }}>
        <div>
          <h2 style={{ fontFamily: "'Playfair Display', serif", fontSize: 28, marginBottom: 4 }}>Kiracılar / Kullanıcılar</h2>
          <p style={{ color: "var(--muted)" }}>{data.length} kullanıcı kayıtlı</p>
        </div>
        <Btn onClick={() => setModal(true)}>+ Yeni Kullanıcı</Btn>
      </div>
      {loading ? <Loader /> : data.length === 0 ? <EmptyState icon="👥" msg="Henüz kullanıcı eklenmemiş" /> : (
        <Card style={{ padding: 0 }}>
          <table>
            <thead><tr><th>Ad Soyad</th><th>E-posta</th><th>Telefon</th><th>Plaka</th><th>Rol</th></tr></thead>
            <tbody>
              {data.map((u, i) => (
                <tr key={u.pkId || i}>
                  <td style={{ fontWeight: 600 }}>{u.fullName || "-"}</td>
                  <td style={{ color: "var(--muted)" }}>{u.email || "-"}</td>
                  <td>{u.phone || "-"}</td>
                  <td>{u.plakaNo || "-"}</td>
                  <td><Badge color={u.role ? "accent" : "muted"}>{u.role ? "Yönetici" : "Kiracı"}</Badge></td>
                </tr>
              ))}
            </tbody>
          </table>
        </Card>
      )}
      <Modal open={modal} onClose={() => setModal(false)} title="Yeni Kullanıcı Ekle">
        <Field label="Ad Soyad"><input value={form.fullName} onChange={e => setForm(f => ({...f, fullName: e.target.value}))} /></Field>
        <Field label="E-posta"><input type="email" value={form.email} onChange={e => setForm(f => ({...f, email: e.target.value}))} /></Field>
        <Field label="Şifre"><input type="password" value={form.password} onChange={e => setForm(f => ({...f, password: e.target.value}))} /></Field>
        <Field label="Telefon"><input value={form.phone} onChange={e => setForm(f => ({...f, phone: e.target.value}))} /></Field>
        <Field label="TC No"><input value={form.tcNo} onChange={e => setForm(f => ({...f, tcNo: e.target.value}))} /></Field>
        <Field label="Plaka No"><input value={form.plakaNo} onChange={e => setForm(f => ({...f, plakaNo: e.target.value}))} /></Field>
        <Field label="Rol">
          <select value={form.role} onChange={e => setForm(f => ({...f, role: e.target.value === "true"}))}>
            <option value="false">Kiracı</option>
            <option value="true">Yönetici</option>
          </select>
        </Field>
        <div style={{ display: "flex", gap: 10, justifyContent: "flex-end", marginTop: 8 }}>
          <Btn variant="ghost" onClick={() => setModal(false)}>İptal</Btn>
          <Btn onClick={save}>Kaydet</Btn>
        </div>
      </Modal>
    </div>
  );
}

// ─── INVOICES PAGE ────────────────────────────────────────────────────────
function InvoicesPage() {
  const { authFetch } = useAuth();
  const toast = useToast();
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [modal, setModal] = useState(false);
  const [form, setForm] = useState({ invoiceMonth: "", invoiceYear: new Date().getFullYear(), invoiceAmount: "", invoiceStatus: false, apartPkId: "" });

  const load = () => authFetch("/Invoice").then(r => r.ok ? r.json() : []).then(d => setData(Array.isArray(d) ? d : [])).catch(() => setData([])).finally(() => setLoading(false));
  useEffect(() => { load(); }, []);

  const save = async () => {
    try {
      const res = await authFetch("/Invoice", { method: "POST", body: JSON.stringify({ ...form, invoiceMonth: +form.invoiceMonth, invoiceYear: +form.invoiceYear, invoiceAmount: +form.invoiceAmount }) });
      if (!res.ok) throw new Error();
      toast.success("Fatura oluşturuldu");
      setModal(false);
      load();
    } catch { toast.error("Hata oluştu"); }
  };

  const MONTHS = ["Oca","Şub","Mar","Nis","May","Haz","Tem","Ağu","Eyl","Eki","Kas","Ara"];

  return (
    <div>
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 32 }}>
        <div>
          <h2 style={{ fontFamily: "'Playfair Display', serif", fontSize: 28, marginBottom: 4 }}>Faturalar</h2>
          <p style={{ color: "var(--muted)" }}>{data.length} fatura</p>
        </div>
        <Btn onClick={() => setModal(true)}>+ Yeni Fatura</Btn>
      </div>
      {loading ? <Loader /> : data.length === 0 ? <EmptyState icon="📄" msg="Henüz fatura oluşturulmamış" /> : (
        <Card style={{ padding: 0 }}>
          <table>
            <thead><tr><th>Dönem</th><th>Tutar</th><th>Durum</th><th>Daire</th></tr></thead>
            <tbody>
              {data.map((inv, i) => (
                <tr key={inv.pkId || i}>
                  <td style={{ fontWeight: 600 }}>{MONTHS[(inv.invoiceMonth || 1) - 1]} {inv.invoiceYear}</td>
                  <td style={{ color: "var(--accent)", fontWeight: 700 }}>₺{(+inv.invoiceAmount || 0).toLocaleString("tr-TR")}</td>
                  <td><Badge color={inv.invoiceStatus ? "success" : "danger"}>{inv.invoiceStatus ? "Ödendi" : "Bekliyor"}</Badge></td>
                  <td style={{ color: "var(--muted)", fontSize: 12 }}>{inv.apartPkId?.slice?.(0,8) || "-"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </Card>
      )}
      <Modal open={modal} onClose={() => setModal(false)} title="Yeni Fatura Ekle">
        <Field label="Ay">
          <select value={form.invoiceMonth} onChange={e => setForm(f => ({...f, invoiceMonth: e.target.value}))}>
            <option value="">Seçin</option>
            {MONTHS.map((m, i) => <option key={i} value={i+1}>{m}</option>)}
          </select>
        </Field>
        <Field label="Yıl"><input type="number" value={form.invoiceYear} onChange={e => setForm(f => ({...f, invoiceYear: e.target.value}))} /></Field>
        <Field label="Tutar (₺)"><input type="number" value={form.invoiceAmount} onChange={e => setForm(f => ({...f, invoiceAmount: e.target.value}))} placeholder="3500" /></Field>
        <Field label="Daire PkId"><input value={form.apartPkId} onChange={e => setForm(f => ({...f, apartPkId: e.target.value}))} placeholder="UUID" /></Field>
        <Field label="Durum">
          <select value={form.invoiceStatus} onChange={e => setForm(f => ({...f, invoiceStatus: e.target.value === "true"}))}>
            <option value="false">Bekliyor</option>
            <option value="true">Ödendi</option>
          </select>
        </Field>
        <div style={{ display: "flex", gap: 10, justifyContent: "flex-end", marginTop: 8 }}>
          <Btn variant="ghost" onClick={() => setModal(false)}>İptal</Btn>
          <Btn onClick={save}>Kaydet</Btn>
        </div>
      </Modal>
    </div>
  );
}

// ─── PAYMENTS PAGE ────────────────────────────────────────────────────────
function PaymentsPage() {
  const { authFetch } = useAuth();
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    authFetch("/Payment/GetAllPayments").then(r => r.ok ? r.json() : []).then(d => setData(Array.isArray(d) ? d : [])).catch(() => setData([])).finally(() => setLoading(false));
  }, []);

  return (
    <div>
      <div style={{ marginBottom: 32 }}>
        <h2 style={{ fontFamily: "'Playfair Display', serif", fontSize: 28, marginBottom: 4 }}>Ödemeler</h2>
        <p style={{ color: "var(--muted)" }}>{data.length} ödeme kaydı</p>
      </div>
      {loading ? <Loader /> : data.length === 0 ? <EmptyState icon="💳" msg="Henüz ödeme kaydı yok" /> : (
        <Card style={{ padding: 0 }}>
          <table>
            <thead><tr><th>Tutar</th><th>Tarih</th><th>Yöntem</th><th>Kullanıcı</th></tr></thead>
            <tbody>
              {data.map((p, i) => (
                <tr key={p.pkId || i}>
                  <td style={{ color: "#10b981", fontWeight: 700 }}>₺{(+p.paymentAmount || 0).toLocaleString("tr-TR")}</td>
                  <td>{p.paymentDate ? new Date(p.paymentDate).toLocaleDateString("tr-TR") : "-"}</td>
                  <td><Badge color="accent">{p.paymentMethod || "Belirtilmedi"}</Badge></td>
                  <td style={{ color: "var(--muted)", fontSize: 12 }}>{p.userId || "-"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </Card>
      )}
    </div>
  );
}

// ─── MESSAGES PAGE ────────────────────────────────────────────────────────
function MessagesPage() {
  const { authFetch, user } = useAuth();
  const toast = useToast();
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [modal, setModal] = useState(false);
  const [form, setForm] = useState({ toUserId: "", messageContent: "", fromUserId: 1, userId: 1 });

  const load = () => authFetch("/Message/GetAllMessages").then(r => r.ok ? r.json() : []).then(d => setData(Array.isArray(d) ? d : [])).catch(() => setData([])).finally(() => setLoading(false));
  useEffect(() => { load(); }, []);

  const send = async () => {
    try {
      const res = await authFetch("/Message", { method: "POST", body: JSON.stringify({ ...form, toUserId: +form.toUserId }) });
      if (!res.ok) throw new Error();
      toast.success("Mesaj gönderildi");
      setModal(false);
      setForm(f => ({ ...f, toUserId: "", messageContent: "" }));
      load();
    } catch { toast.error("Hata oluştu"); }
  };

  return (
    <div>
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 32 }}>
        <div>
          <h2 style={{ fontFamily: "'Playfair Display', serif", fontSize: 28, marginBottom: 4 }}>Mesajlar</h2>
          <p style={{ color: "var(--muted)" }}>{data.length} mesaj</p>
        </div>
        <Btn onClick={() => setModal(true)}>+ Yeni Mesaj</Btn>
      </div>
      {loading ? <Loader /> : data.length === 0 ? <EmptyState icon="💬" msg="Henüz mesaj yok" /> : (
        <div style={{ display: "flex", flexDirection: "column", gap: 12 }}>
          {data.map((m, i) => (
            <Card key={m.pkId || i} style={{ animation: "fadeUp 0.3s ease" }}>
              <div style={{ display: "flex", justifyContent: "space-between", marginBottom: 8 }}>
                <div style={{ display: "flex", gap: 12, alignItems: "center" }}>
                  <div style={{ width: 36, height: 36, borderRadius: "50%", background: "linear-gradient(135deg, #f0a500, #ff6b35)", display: "flex", alignItems: "center", justifyContent: "center", fontSize: 16 }}>💬</div>
                  <div>
                    <div style={{ fontWeight: 600, fontSize: 14 }}>Gönderen: {m.fromUserId || "-"} → {m.toUserId || "-"}</div>
                    <div style={{ fontSize: 12, color: "var(--muted)" }}>{m.messageDate ? new Date(m.messageDate).toLocaleString("tr-TR") : "-"}</div>
                  </div>
                </div>
              </div>
              <p style={{ color: "var(--text)", fontSize: 14, lineHeight: 1.6 }}>{m.messageContent || ""}</p>
            </Card>
          ))}
        </div>
      )}
      <Modal open={modal} onClose={() => setModal(false)} title="Yeni Mesaj Gönder">
        <Field label="Alıcı Kullanıcı ID"><input type="number" value={form.toUserId} onChange={e => setForm(f => ({...f, toUserId: e.target.value}))} placeholder="2" /></Field>
        <Field label="Mesaj">
          <textarea value={form.messageContent} onChange={e => setForm(f => ({...f, messageContent: e.target.value}))} rows={4} placeholder="Mesajınızı yazın..." style={{ resize: "vertical" }} />
        </Field>
        <div style={{ display: "flex", gap: 10, justifyContent: "flex-end", marginTop: 8 }}>
          <Btn variant="ghost" onClick={() => setModal(false)}>İptal</Btn>
          <Btn onClick={send}>Gönder</Btn>
        </div>
      </Modal>
    </div>
  );
}

// ─── APP SHELL ────────────────────────────────────────────────────────────
function AppShell() {
  const { token } = useAuth();
  const [page, setPage] = useState("dashboard");

  if (!token) return <LoginPage />;

  const pages = {
    dashboard: <Dashboard />,
    aparts: <ApartsPage />,
    users: <UsersPage />,
    invoices: <InvoicesPage />,
    payments: <PaymentsPage />,
    messages: <MessagesPage />,
  };

  return (
    <div style={{ display: "flex", minHeight: "100vh" }}>
      <Sidebar page={page} setPage={setPage} />
      <main style={{ flex: 1, padding: 40, overflowY: "auto" }}>
        {pages[page]}
      </main>
    </div>
  );
}

// ─── ROOT ─────────────────────────────────────────────────────────────────
export default function App() {
  return (
    <>
      <style>{CSS}</style>
      <AuthProvider>
        <ToastProvider>
          <AppShell />
        </ToastProvider>
      </AuthProvider>
    </>
  );
}
