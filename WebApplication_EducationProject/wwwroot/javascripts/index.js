const loginButtonOpen = document.querySelector('.login-button');
const loginButtonClose = document.querySelector('.login-iframe .close');
const modelLogin = document.querySelector('.login-iframe');

const frostForm = document.querySelector('.frost');


const singupButtonOpen = document.querySelector('.signup-button');
const singupButtonClose = document.querySelector('.signup-iframe .close');
const modelSingup = document.querySelector('.signup-iframe');



function showLogin() {
    modelLogin.classList.add('show-login');
    frostForm.classList.add('frost-form');
}

function hideLogin() {
    modelLogin.classList.remove('show-login');
    frostForm.classList.remove('frost-form');
}

function showSignup() {
    modelSingup.classList.add('show-signup');
    frostForm.classList.add('frost-form');
}

function hideSignup() {
    modelSingup.classList.remove('show-signup');
    frostForm.classList.remove('frost-form');
}

loginButtonOpen.addEventListener('click', showLogin);
loginButtonClose.addEventListener('click', hideLogin);

singupButtonOpen.addEventListener('click', showSignup);
singupButtonClose.addEventListener('click', hideSignup);




    