export function toggleSearchBox() {
    const searchButton = document.querySelector('.search');
    const searchBox = document.querySelector('#search-box');

    function toggleVisibility() {
        if (searchBox.style.display === 'none' || searchBox.style.display === '') {
            searchBox.style.display = 'block';
        } else {
            searchBox.style.display = 'none';
        }
    }

    searchButton.addEventListener('click', toggleVisibility);
}