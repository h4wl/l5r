var map = L.map('map').fitWorld();

L.tileLayer('https://img.dhb.dev/l5r/maps/leaflets/{z}/{x}/{y}.png', {
    maxZoom: 6,
    noWrap: true
}).addTo(map);