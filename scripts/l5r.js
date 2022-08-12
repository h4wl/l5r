const l5r = {
    tocHrefSelected: location.href
};

l5r.tocOnClick = function(link){
    l5r.tocHrefSelected = link;
    const bsOffcanvas = bootstrap.Offcanvas.getInstance("#tableOfContents");
    if (!!bsOffcanvas) {
        bsOffcanvas.hide(); 
    } else {
        location.href = l5r.tocHrefSelected;
    }
    
}

const myOffcanvas = document.getElementById('tableOfContents')
myOffcanvas.addEventListener('hidden.bs.offcanvas', event => {
    if (l5r.tocHrefSelected !== location.href ) {
        setTimeout(()=> location.href = l5r.tocHrefSelected, 0);
    }
})






