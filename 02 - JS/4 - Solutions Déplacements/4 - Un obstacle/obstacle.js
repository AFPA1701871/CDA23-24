function deplace(dx, dy) {
    var carre = document.getElementById("carre");
    var styleCarre = window.getComputedStyle(carre, null);
    var t = parseInt(styleCarre.top);
    var l = parseInt(styleCarre.left);
    var w = parseInt(styleCarre.width);
    var h = parseInt(styleCarre.height);
    var styleObst = window.getComputedStyle(document.getElementById('obstacle'), null);
    var tob = parseInt(styleObst.top);
    var lob = parseInt(styleObst.left);
    var wob = parseInt(styleObst.width);
    var hob = parseInt(styleObst.height);

    if (depl_ok(tob, lob, wob, hob, t + dy, l + dx, w, h)) {
        carre.style.top = t + dy + 'px';
        carre.style.left = l + dx + 'px';
    }
}

function depl_ok(tob, lob, wob, hob, t, l, w, h) {
    // formule de détection des collisions
   if (l < lob + wob && l + w > lob && t < tob + hob && t + h > tob) {
        return false
    }
    return true;
}
document.addEventListener("keydown",function(event) {
    var event = event || window.event, // pour la compatibilite avec tous les navigateurs
        keyCode = event.keyCode;
        var speed = 15;
    // On détecte l'événement puis selon la fleche, on appelle deplace
    switch (keyCode) {
        case 38:
            deplace(0, -speed);
            break;
        case 40:
            deplace(0, speed);
            break;
        case 37:
            deplace(-speed, 0);
            break;
        case 39:
            deplace(speed, 0);
            break;
        case 36:
            deplace(-speed, -speed);
            break;
        case 35:
            deplace(-speed, speed);
            break;
        case 33:
            deplace(speed, -speed);
            break;
        case 34:
            deplace(speed, speed);
            break;
    }
});
