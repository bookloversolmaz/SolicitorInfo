const BASE_URL = "https://localhost:7077/api/solicitors?location=London";

export async function scrape(locations) {
    const response = await fetch(`${BASE_URL}/scrape`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(locations)
    });

    return await response.json();
}

export async function getSolicitors() {
    const response = await fetch(`${BASE_URL}/scrape`);
    return await response.json();
}