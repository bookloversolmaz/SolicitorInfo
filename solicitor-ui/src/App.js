import { useState } from "react";
import { scrape, getSolicitors } from "./api";

function App() {
    const [locations, setLocations] = useState(["London"]);
    const [data, setData] = useState([]);

    const runScrape = async () => {
        const result = await scrape(locations);
        setData(result);
    };

    const loadData = async () => {
        const result = await getSolicitors();
        setData(result);
    };

    return (
        <div style={{ padding: 20 }}>
            <h1>Solicitor Scraper</h1>

            <button onClick={runScrape}>
                Run Scrape
            </button>

            <button onClick={loadData} style={{ marginLeft: 10 }}>
                Load Saved Data
            </button>

            <hr />

            {data.map((s) => (
                <div key={s.id} style={{ marginBottom: 15 }}>
                    <h3>{s.solicitorName}</h3>
                    <p>{s.address}</p>
                    <p>{s.phoneNumber}</p>
                    <p>{s.location}</p>
                </div>
            ))}
        </div>
    );
}

export default App;