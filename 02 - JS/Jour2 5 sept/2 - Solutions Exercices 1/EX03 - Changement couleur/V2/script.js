listeCouleursParag = ['blue', 'black'];
listeCouleursTitre = ['titleA', 'titleB', 'titleC'];

lesParagraphes = document.querySelectorAll("p");

lesParagraphes.forEach(para => {
    para.addEventListener("click", changeColorP);
});
lesTitres = document.querySelectorAll("h1, h2, h3");
lesTitres.forEach(title => {
    title.addEventListener("click", changeColorT);
});

var iteration = 1;

function changeColorP(event) {
    paragraphe = event.target;
    // if (paragraphe.classList.contains("para2")) {
    //     paragraphe.classList.remove("para2");
    // } else {
    //     paragraphe.classList.add("para2");
    // }
    // toggle permet d'enlever si présent
    // le 2eme parametre de toggle à true permet de forcer l'ajout si non présent
    paragraphe.classList.toggle("para2");
}

function changeColorT(event) {
    titre = event.target;
    tousTitreNiveau = document.querySelectorAll(titre.localName); // localName correspond au tag name en minuscule
    tousTitreNiveau.forEach(title => {
        for (let i = 0; i < listeCouleursTitre.length; i++) {
            const element = listeCouleursTitre[i];
            title.classList.toggle(element, iteration % listeCouleursTitre.length == i);
        }
    });
    iteration++;
}