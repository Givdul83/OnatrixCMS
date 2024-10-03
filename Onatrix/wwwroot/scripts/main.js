import { fadeInOnScroll } from './fadeScript.js';
import { rotateOnScroll } from './rotateScript.js';
import { validateForm } from './validationScript.js';
import { toggleSearchBox } from './searchScript.js';


document.addEventListener('DOMContentLoaded', function () {
    fadeInOnScroll();
    rotateOnScroll();
    validateForm();
    toggleSearchBox();
    
});
