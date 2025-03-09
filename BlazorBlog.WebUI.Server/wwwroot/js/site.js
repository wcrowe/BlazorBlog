﻿window.toggleDarkMode = () => {
    document.documentElement.classList.toggle('dark');
    localStorage.setItem('darkMode', document.documentElement.classList.contains('dark'));
};

window.initDarkMode = () => {
    if (localStorage.getItem('darkMode') === 'true') {
        document.documentElement.classList.add('dark');
    }
};