import { useEffect } from "react";
import connection from "./signalrConnection";

function App() {
  useEffect(() => {
    connection.start()
      .then(() => {
        console.log("✅ Connected to SignalR Hub");
        
        // Example: listen for a server message
        connection.on("ReceiveMessage", (user, message) => {
          console.log("Message from hub:", user, message);
        });
      })
      .catch(err => console.error("❌ SignalR Connection Error: ", err));
  }, []);

  const sendMessage = async () => {
    try {
      await connection.invoke("SendMessage", "FrontendUser", "Hello from React!");
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div>
      <h1>React + SignalR</h1>
      <button onClick={sendMessage}>Send Test Message</button>
    </div>
  );
}

export default App;
