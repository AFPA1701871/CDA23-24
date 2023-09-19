function deplace(dleft, dtop) {
    // permet de deplacer le calque selon 2 directions left et top
    //on recupere le carré rouge
    var calque = document.getElementById('carre');
    //on recupere son style (tout le CSS)
    var styleCalque = window.getComputedStyle(calque, null);
    //on recupere les positions left et top actuelles
    var topActuel = styleCalque.top;
    var leftActuel = styleCalque.left;
    //on modifie les positions let et top actuelles
    calque.style.top = parseInt(topActuel) + dtop + 'px';
    calque.style.left = parseInt(leftActuel) + dleft + 'px';
}

document.addEventListener("keydown",function(event) {
         keyCode = event.code;
    // On détecte l'événement puis selon la fleche, on appelle deplace
    switch (keyCode) {
        case "ArrowUp":
            deplace(0, -5);
            break;
        case "ArrowDown":
            deplace(0, 5);
            break;
        case "ArrowLeft":
            deplace(-5, 0);
            break;
        case "ArrowRight":
            deplace(5, 0);
            break;
    }
});