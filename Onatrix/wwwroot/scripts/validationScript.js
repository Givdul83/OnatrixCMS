export function validateForm() {
    const name = document.getElementById('name');
    const email = document.getElementById('email');
    const phone = document.getElementById('phone');
    const emailPattern = /[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}/;
    const phonePattern = /^[0-9]{7,14}$/;

    name.addEventListener('input', function () {
        validateField(name, name.value.length >= 2);
    });

    email.addEventListener('input', function () {
        validateField(email, emailPattern.test(email.value));
    });

    phone.addEventListener('input', function () {
        validateField(phone, phonePattern.test(phone.value));
    });

    function validateField(field, isValid) {
        if (isValid) {
            field.classList.add('is-valid');
            field.classList.remove('is-invalid');
        } else {
            field.classList.add('is-invalid');
            field.classList.remove('is-valid');
        }
    }
}