import { useState, useEffect } from "react";
import { getSolicitors, scrape, getLocations } from "./api";

export default function App() {
    // The hooks
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);
    const [locationsList, setLocationsList] = useState([]);
    const [selectedLocation, setSelectedLocation] = useState("");

    // LOAD DATA FUNCTION, which called backend getSolicitors and updates UI with results
    const loadData = async (loc) => {
        const result = await getSolicitors(loc);
        setData(result);
    };

    // INITIAL LOAD
    useEffect(() => {
        const init = async () => {
            // gets dropdown values from backend and stores them for dropdown.
            const locations = await getLocations();
            setLocationsList(locations);

            // checks that backend returns data.
            if (locations.length > 0) {
                setSelectedLocation(locations[0]);
                loadData(locations[0]);
            }
        };

        init();
    }, []);

    // CHANGE LOCATION triggered when user selects a dropdown item, updates states and refreshes results instantly.
    const handleChange = (e) => {
        const loc = e.target.value;
        setSelectedLocation(loc);
        loadData(loc);
    };

    // RUN SCRAPE THEN REFRESH triggered when user clicks Run scrape, shows loading state, calls
    // backend scrape API and refreshes UI after scraping.
    const runScrape = async () => {
        try {
            setLoading(true);
            await scrape([selectedLocation]);
            await loadData(selectedLocation);
        } finally {
            setLoading(false);
        }
    };

    // The UI
    return (
        <div style={{ padding: 20 }}>
            <h1>Solicitors</h1>

            {/* DROPDOWN FILTER */}
            <select value={selectedLocation} onChange={handleChange}>
                {locationsList.map((loc) => (
                    <option key={loc} value={loc}>
                        {loc}
                    </option>
                ))}
            </select>

            {/* BUTTONS */}
            <button onClick={runScrape} disabled={loading}>
                {loading ? "Scraping..." : "Run Scrape"}
            </button>

            <button
                onClick={() => loadData(selectedLocation)}
                style={{ marginLeft: 10 }}
            >
                Load Data
            </button>

            {/* RESULTS */}
            <ul>
                {data.map((s) => (
                    <li key={s.id}>
                        <b>{s.solicitorName}</b> - {s.address}
                    </li>
                ))}
            </ul>
        </div>
    );
}