let divDesserts = document.querySelector('#divDesserts');
let btnAddDessert = document.querySelector('#btnAddDessert');
let listDesserts = document.querySelectorAll('.dessert');

listDesserts.forEach(element => {
    element.addEventListener('click', supprimer);
});

btnAddDessert.addEventListener('click', () => {
    let newDessert = prompt('Quel dessert voulez vous ajouter ?');
    //divDesserts.innerHTML += '<li class="dessert">' + newDessert + '</li>';
    let newLi = document.createElement("li");
    newLi.classList.add("dessert");
    newLi.innerHTML = newDessert;
    newLi.addEventListener('click', supprimer);
    divDesserts.appendChild(newLi);
});

function supprimer(event){
    event.target.remove();
}

