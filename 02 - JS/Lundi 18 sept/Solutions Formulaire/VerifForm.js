//Initialise 3 constante afin d'initialisé les couleurs ( la valeur entre "" correspond a la classe css qui sera ajouter ).
const green = "inputCorrect";
const white = "inputVide";
const red = "inputIncorrect";

/************ FIN API MAIL************/

var listForms = document.querySelectorAll('form');

//Récupère tous les inputs du formulaire et effectue une première vérification & ajoute les eventListener sur chacun d'entre eux.
listForms.forEach(formulaire => {
    // pour chaque formulaire, on récupère les inputs
    let listInputs = formulaire.querySelectorAll("input:not([type='submit']):not([type='reset']:not([type='button']),select,textarea");
    let submit = formulaire.querySelector("input[type='submit'], button[type='submit']");
    let reset = formulaire.querySelector("input[type='reset']");
    let listInputsValidity = {}; // tableau qui contient pour chaque input : vrai si l'input est valide, faux sinon

    // on lance la vérification sur tous les champs du formulaire
    InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire);

    var listePassword = formulaire.querySelectorAll("input[type=password]");
    listePassword.forEach(pwd => {

        // on empeche le copier coller sur les mots de passe
        pwd.addEventListener('contextmenu', annule);
        pwd.addEventListener("paste", annule);

        // on recupere l'input du password ayant le pattern
        let aide = pwd.getAttribute("pattern");
        if (aide != null) {
            pwd.addEventListener("input", function (event) {
                document.getElementById("infoMDP").style.display = "flex";
                let aideMdp = document.getElementById("infoMDP");
                let lesImages = aideMdp.getElementsByTagName("i");
                let lesCheck = ["(?=.*[A-Z])", "(?=.*[a-z])", "(?=.*[0-9])", "(?=.*[!@#\$%\^&\*+])", "([a-zA-Z0-9!@#\$%\^&\*+]{8,})"];
                for (let i = 0; i < lesCheck.length; i++) {
                    if (RegExp(lesCheck[i]).test(pwd.value)) {
                        //la condition est vérifiée, on met la coche verte correspondente
                        lesImages[i].classList = "far fa-check-circle fa-green";
                    } else {
                        lesImages[i].classList = "far fa-times-circle fa-red";
                    }
                }
            });

            // suppression de l'aide mot de passe quand on quitte le champ
            pwd.addEventListener("blur", function (event) {
                document.getElementById("infoMDP").style.display = "none";
            });
        }
    });

    if (reset != undefined) {
        // Initialise le bouton reset
        reset.addEventListener('click', function () {
            resetInputs(listInputs, listInputsValidity, submit, formulaire)
        });
    }

    listInputs.forEach(element => {
        element.addEventListener('input', function () {
            // on déclenche la vérification sur tous les champs du formulaire à chaque changement d'input
            InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire)
        });
    });
});

/*****************************Mot de passe *************************************/

//gestion de l'oeil dans le mot de passe
var listeOeil = document.getElementsByClassName("oeil");
for (let i = 0; i < listeOeil.length; i++) {
    // on affiche un petit oeil qui permet de voir de mot de passe 
    // listeOeil[i].addEventListener("mousedown", function () {
    //     affichePassWord(listeOeil[i],true);
    // });
    // listeOeil[i].addEventListener("mouseup", function () {
    //     affichePassWord(listeOeil[i],false);
    // });
    console.log(listeOeil[i]);
     listeOeil[i].addEventListener("click", function () {
        // console.log('click')
            affichePassWord(listeOeil[i]);
     });

}
/***********************************Function************************************/

/**
 * Vérifie que le pattern de l'input est respecté et que l'input n'est pas vide si il est required.
 * Change l'aspect des inputs en fonction de leur état
 * Active ou pas le bouton submit
 * @param {[object]} listInputs 
 * @param {[]} listInputsValidity 
 * @param {object} submit 
 * @param {object} formulaire 
 */
function InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire) {
    // Pour chaque input, on vérifie sa validité
    listInputs.forEach(element => {
        if (element.checkValidity()) {
            listInputsValidity[element.name] = true;
        } else {
            listInputsValidity[element.name] = false;
        }
    });
    // Vérification spéciale pour l'adresse mail à l'inscription
    verifEmail(listInputsValidity, formulaire);
    // Vérification spéciale pour le mot de passe
    verifPassword(listInputsValidity, formulaire);
    // Change l'aspect des inputs en fonction de leur état
    changeColor(listInputs, listInputsValidity);
    // Active ou pas le bouton submit
    revealSubmitButton(listInputsValidity, submit);
};


/**
 * Vérifie que l'adresse mail entree à l'inscription n'existe pas 
 * @param {[]} listInputsValidity 
 */
function verifEmail(listInputsValidity, formulaire) {
    let mailSaisi = formulaire.querySelector("#adresseMail");
    let infoMail = formulaire.querySelector("#infoEmail");
    if (mailSaisi != null && listemail.includes(mailSaisi.value)) { //modif
        listInputsValidity['adresseMail'] = false;
        infoMail.classList.remove('noDisplay');
    }
    else if (infoMail != null) {
        infoMail.classList.add('noDisplay');
    }
};

/**
 * Vérification du mot de passe et de la confirmation de mot de passe.
 * @param {[]} listInputsValidity 
 * @param {object} formulaire 
 */
function verifPassword(listInputsValidity, formulaire) {
    let listePassword = formulaire.querySelectorAll("input[type=password]");
    if (listePassword.length == 2 && listePassword[0].value != listePassword[1].value) { //modif
        listInputsValidity[listePassword[1].name] = false;
    }
};

/**
 * Change la couleur des inputs en fonction de la validité de l'input.
 * @param {[object]} listInputs 
 * @param {[]} listInputsValidity 
 */
function changeColor(listInputs, listInputsValidity) {
    listInputs.forEach(element => {
        // on enlève les classes déja affectée
        element.classList.remove(green, red, white);
        // en fonction des coditions, on ajoute les bonnes classes
        if (listInputsValidity[element.name] == true && element.value != "") {
            element.classList.add(green);
        } else if (listInputsValidity[element.name] == false && (element.type == "number" || element.value != "")) {
            element.classList.add(red);
        } else {
            element.classList.add(white);
        }
    });
};

/**
 * Reset tous les inputs du formulaire en m'étant la valeur par default.
 * @param {[object]} listInputs 
 * @param {[]} listInputsValidity 
 * @param {object} submit 
 */
function resetInputs(listInputs, listInputsValidity, submit, formulaire) {
    listInputs.forEach(element => {
        element.value = element.defaultValue;
    });
    // on relance la vérification sur tous les champs
    InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire);
};

/**
 * Affiche le button submit si tous les inputs sont correctement remplis.
 * @param {[]} listInputsValidity 
 * @param {object} submit 
 */
function revealSubmitButton(listInputsValidity, submit) {
    // on active le bouton
    submit.disabled = false;
    // si un input est mal rempli on désactive le bouton
    if (Object.values(listInputsValidity).indexOf(false) != -1) {
        submit.disabled = true;
    }
};

/**
 * Annule l'action associé à la touche ou au clic
 * @param {*} event 
 */
function annule(event) {
    event.preventDefault();
}

/**
 * Change le type de l'input mot de passe
 * @param {boolean} flag 
 */
// function affichePassWord(input, flag) {
//     inp = input.previousElementSibling;
//     if (flag) inp.type = "text";
//     else inp.type = "password";
// }
function affichePassWord(input) {
    inp = input.previousElementSibling;

    console.log(inp)
    if (inp.type == "password"){
        inp.type = "text"
    }else if(inp.type == "text"){
        console.log('txt')
        inp.type = "password";
    }
}