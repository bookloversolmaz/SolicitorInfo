const BASE_URL = "http://localhost:5034/api/solicitors";

export async function getSolicitors(location) {
    const response = await fetch(`${BASE_URL}?location=${location}`);
    return await response.json();
}

export async function scrape(locations) {
    const response = await fetch("http://localhost:5034/api/scrape", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(locations)
    });

    if (!response.ok) {
        const text = await response.text();
        throw new Error(text);
    }

    return await response.json();
}

export async function getLocations() {
    const res = await fetch(`${BASE_URL}/locations`);
    return await res.json();
}