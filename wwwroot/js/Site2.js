// Initialize and add the map
function initMap() {
    // The location of Uluru
    const cemetery = { lat: 39.0619011, lng: -84.5550003 };
    // The map, centered at cemetery
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 4,
        center: cemetery,
    });
    // The marker, positioned at cemetery
    const marker = new google.maps.Marker({
        position: cemetery,
        map: map,
    });
}
