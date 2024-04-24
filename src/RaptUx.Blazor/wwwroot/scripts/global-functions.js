function setIcons() {
    const elements = document.getElementsByClassName("lpx-menu-item-icon");

    for (let i = elements.length - 1; i >= 0; i--) {
        let element = elements[i];
        let logoContainer = element.children[0];
        
        if (logoContainer.classList[1] != null) {
            if (logoContainer.classList[1].includes("icon-name-")) {
                logoContainer.textContent = logoContainer.classList[1].replace("icon-name-", '');
            } else {
                logoContainer.textContent = 'shield';
            }
        }
        
        logoContainer.className += " material-symbols-outlined";
        logoContainer.style.fontSize = "2em";
    }
}