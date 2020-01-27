var countPlayers = 2
var addPlayerButton = document.querySelector(".add-new-player")
var avatarsList = document.querySelectorAll(".player-container")
var avatars = document.querySelectorAll("#select-avatar-popup .avatar")
var selectAvatarPopup = $("#select-avatar-popup")
var handlerToAvatarPlayer

window.addEventListener('load', () => {

    /*-------------------- 
    Start Game Functions
    --------------------*/

    addPlayerButton.addEventListener("click", addPlayer)
    avatarsList.forEach(a => {
        a.addEventListener("click", showAvatarList)
    })

    avatars.forEach(a => {
        a.addEventListener("click", setAvatar)
    })


    function addPlayer() {
        var players = document.getElementsByClassName("player-container")

        if (countPlayers < 6) {
            players[countPlayers].style.display = "block"
            countPlayers++
        }
        else {
            $('#alert-max-players').modal('show')
        }
    }

    function showAvatarList() {
        handlerToAvatarPlayer = this
        selectAvatarPopup.modal('show')
    }

    function setAvatar() {
        handlerToAvatarPlayer.querySelector(".player-avatar").style.backgroundImage = 'url("' + this.dataset.url + '")'
    }

})