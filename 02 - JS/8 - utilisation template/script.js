grille = document.getElementById("ici"); // on récupère la grille pour ajouter une ligne

// récupérer un template dans le html les différentes techniques
// temp = document.getElementsByTagName("template")[0]; // on récupère le template
// temp = document.getElementsById("templateUn"); // on récupère le template
// temp = document.querySelector("#templateUn"); // on récupère le template
temp = document.querySelector("template"); // on récupère le template

//on recopie le template
// const element = temp.content.cloneNode(true); // on clone le template
// grille.appendChild(element);    // on ajoute la ligne à la grille

// on recopie le template en boucle
// for (let i = 0; i < 10; i++) {
//     const element2 = temp.content.cloneNode(true); // on clone le template
//     grille.appendChild(element2);    // on ajoute la ligne à la grille
// }

// on modifie le template avant de l'ajouter
for (let i = 0; i < 10; i++) {
    const element3 = temp.content.cloneNode(true); // on clone le template
    grille.appendChild(element3);    // on ajoute la ligne à la grille
    grille.innerHTML = grille.innerHTML.replaceAll("DIV", "ceci est une div");
    grille.innerHTML = grille.innerHTML.replaceAll("VALEUR", i);
}
