const BASE_URL = "http://localhost:5034/api/solicitors"; // base address of backend API including controller route.

// Imports into react the solicitors details from the backend. GET SOLICITORS
export async function getSolicitors(location) {
    const response = await fetch(`${BASE_URL}?location=${location}`);
    return await response.json();
}

// scrapes for locations. SCRAPE DATA.
export async function scrape(locations) {
    const response = await fetch("http://localhost:5034/api/scrape", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(locations) // converts JS array into JSON
    });

    // in case of backend error, throw an error message
    if (!response.ok) {
        const text = await response.text();
        throw new Error(text);
    }

    return await response.json();
}

// Fetches dropdown list of cities. GET LOCATIONS.
export async function getLocations() {
    const res = await fetch(`${BASE_URL}/locations`);
    return await res.json();
}