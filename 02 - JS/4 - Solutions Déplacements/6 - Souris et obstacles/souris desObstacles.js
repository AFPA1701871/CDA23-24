function deplace(l,t) { // left et top de la ou je veux aller
    var deplacement_ok = true;
    var styleCarre = window.getComputedStyle(document.getElementById('carre'), null);
    var w = parseInt(styleCarre.width);
    var h = parseInt(styleCarre.height);
    var listeObs = document.querySelectorAll('.obstacle');
    listeObs.forEach(function (elt) {
        var styleObst = window.getComputedStyle(elt, null);
        var tob = parseInt(styleObst.top);
        var lob = parseInt(styleObst.left);
        var wob = parseInt(styleObst.width);
        var hob = parseInt(styleObst.height);
        deplacement_ok = deplacement_ok && depl_ok(tob, lob, wob, hob, t , l, w, h);

    });
    if (deplacement_ok) {
        document.getElementById('carre').style.top = t  + 'px';
        document.getElementById('carre').style.left = l + 'px';
    }
}

function depl_ok(tob, lob, wob, hob, t, l, w, h) {
    if (l < lob + wob && l + w > lob && t < tob + hob && t + h > tob) {
        return false
    }
    return true;
}
var enfonce = false;//repere si la souris est relaché ou enfonce
var carre = document.getElementById("carre");

// on ecoute l'enfoncement de la souris sur le carré
carre.addEventListener("mousedown", souris_enfonce);
// on écoute la relache de la souris sur tout le document
document.addEventListener("mouseup", souris_lache);
document.addEventListener("mousemove", souris_bouge);


function souris_enfonce(e) {
    enfonce = true;
    decalageX = e.clientX - carre.style.left.substring(0,carre.style.left.length-2);
    decalageY = e.clientY - carre.style.top.substring(0,carre.style.top.length-2);
}

function souris_lache() {
    enfonce = false;
    console.log(enfonce);
}

function souris_bouge(e) {
    if (enfonce) {
        console.log(e.clientX - decalageX,e.clientY - decalageY)
        deplace(e.clientX - decalageX,e.clientY - decalageY)
    }
}