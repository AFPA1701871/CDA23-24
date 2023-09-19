var enfonce = false;//repere si la souris est relaché ou enfonce
var carre = document.getElementById("square");


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
        carre.style.left = (e.clientX - decalageX) + 'px';
        carre.style.top = (e.clientY - decalageY) + 'px';
    }
}