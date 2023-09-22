/* on mémorise l'emplacement de la case vide */
var elig = 3;
var ecol = 3;
var nbclicks = 0;
/* Fonction qui échange la case (lig,col) avec la case vide */
function deplace(e) {
    var boutonClique = e.target;
    var monID = boutonClique.id;
    var lig = monID.substring(4, 5);
    var col = monID.substring(5, 6);
    var idVide = "case" + elig + ecol
    var boutonVide = document.getElementById(idVide);
    if (
        ((elig == lig) && ((col == ecol - 1) || (col == parseInt(ecol) + 1))) ||
        ((ecol == col) && ((lig == elig - 1) || (lig == parseInt(elig) + 1)))
    ) {
        /* mise à jour du nombre de clics */
        nbclicks = nbclicks + 1;
        /* on récupère l'élément compteur */
        var noeud_compteur = document.getElementById('compteur');
        /* mettre à jour la valeur */
        noeud_compteur.innerHTML = nbclicks;

        /*On change les textes*/
        boutonVide.innerHTML = boutonClique.innerHTML;
        boutonClique.innerHTML = "";
        /* on échange les classes des deux boutons */
        boutonClique.setAttribute('class', 'emptycase');
        boutonVide.setAttribute('class', 'case');
        /* on enlève le "focus" sur le bouton cliqué */
        boutonClique.blur();
        /* on mémorise l'emplacement de la case vide */
        elig = lig;
        ecol = col;

    }
}

function initGame() {
    var tab= [];
    for (let i = 1; i < 9; i++) {
        tab[i - 1] = i;
    }
    var lesCases = document.getElementsByClassName("case");
    for (let i = 0; i < 8; i++) {
        alea = Math.ceil(Math.random() * tab.length-1);
        lesCases[i].innerHTML = tab[alea];
        tab.splice(alea,1);
        lesCases[i].addEventListener("click", deplace);
    }
	document.getElementsByClassName("emptycase")[0].addEventListener("click", deplace);
}
initGame();