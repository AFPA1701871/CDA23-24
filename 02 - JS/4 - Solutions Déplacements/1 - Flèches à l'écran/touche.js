function deplace(dleft, dtop) {
    // permet de deplacer le calque selon 2 directions left et top
    //on recupere le carré rouge
    var calque = document.getElementById('calque');
    //on recupere son style (tout le CSS)
    var styleCalque = window.getComputedStyle(calque, null);
    //on recupere les positions left et top actuelles
    var topActuel = styleCalque.top;
    var leftActuel = styleCalque.left;
    //on modifie les positions let et top actuelles
    calque.style.top = parseInt(topActuel) + dtop + 'px';
    calque.style.left = parseInt(leftActuel) + dleft + 'px';
}
document.getElementById("up").addEventListener("click", function() { deplace(0, -5); });
document.getElementById("left").addEventListener("click", function() { deplace(-5, 0); });
document.getElementById("down").addEventListener("click", function() { deplace(0, 5); });
document.getElementById("right").addEventListener("click", function() { deplace(5, 0); });