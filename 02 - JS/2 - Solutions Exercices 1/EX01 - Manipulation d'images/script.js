/******** 1ere methode ******** */
// eteint = document.getElementById("eteint");
// allumee = document.getElementById("allumee");

// console.log(eteint.src);
// console.log(allumee.src);
// // eteint.addEventListener("click",function (){})
// // eteint.addEventListener("click",()=>{})
// eteint.addEventListener("click",clickAmpoule)
// allumee.addEventListener("click",clickAmpoule)


// function clickAmpoule(event) {
//     imageAffiche = event.target;
//     if ( imageAffiche == eteint)
//     {
//         eteint.classList.add("noDisplay");
//         allumee.classList.remove("noDisplay");
//     }
//     else{
//         allumee.classList.remove("noDisplay");
//         eteint.classList.add("noDisplay");
//     }
// }

/******** 2eme methode ******** */
// lesImages = document.querySelectorAll("[data-image]");
// lesImages.forEach(element => {
//     element.addEventListener("click", clickAmpoule2);
// });
// function clickAmpoule2(event) {
//     imageCliquee = event.target
//     imageCliquee.classList.add("noDisplay");
//     if (imageCliquee.getAttribute("data-image") == "eteint") {
//         document.querySelector("[data-image=allumee]").classList.remove("noDisplay");
//     }
//     else
//         document.querySelector("[data-image=eteint]").classList.remove("noDisplay");

// }

/**************3eme methode ******************** */
lesImages = document.querySelectorAll("[data-image]");
lesImages.forEach(element => {
    element.addEventListener("click", clickAmpoule3);
});

function clickAmpoule3(event){
    imageCliquee = event.target;
    if( imageCliquee.getAttribute("data-image")=="eteint")
    {
        imageCliquee.classList.add("noDisplay");
        imageCliquee.previousElementSibling.classList.remove("noDisplay");
    }
    else{
        imageCliquee.classList.add("noDisplay");
        imageCliquee.nextElementSibling.classList.remove("noDisplay");
    }
// utiliser la fonction classList.toogle pour simplifier l'écriture
}


/**************4eme methode ******************** */
// limage = document.getElementsByTagName("img")[0];
// limage.addEventListener("click", clickAmpoule4);

// function clickAmpoule4(event){
//     imageCliquee = event.target;
//     if( imageCliquee.getAttribute("data-image")=="eteint")
//     {
//         imageCliquee.src="./IMG/ampoule allumee.png";
//     }
//     else{
//         imageCliquee.src="./IMG/ampoule eteinte.png";
//     }

// }
