// on définit nos variables
var card = document.getElementById("card");
var side = 0; // 0 = recto, 1 = verso

// on affiche notre carte et on ajoute un évènement 'click'
card.innerHTML = "<img src='images/card_off.png' alt=''>";
card.addEventListener("click", turnOver);

// retourne la carte selon le côté
function turnOver() {
    if (side == 0) {
        card.innerHTML = "<img src='images/card_on.png' alt=''>";
        side = 1;

        // appelle turnBack au bout de 3sec
        setTimeout(turnBack, 3000);
    }
    else {
        card.innerHTML = "<img src='images/card_off.png' alt=''>";
        side = 0;
    }
}

// retourne la carte sur le côté originel
function turnBack() {
    if (side == 1) {
        card.innerHTML = "<img src='images/card_off.png' alt=''>";
        side = 0;
    }
}