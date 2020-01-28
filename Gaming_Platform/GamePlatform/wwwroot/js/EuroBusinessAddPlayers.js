var countPlayers = 3
var addPlayerButton = document.querySelector(".add-new-player")
var avatarsList = document.querySelectorAll(".player-avatar")
var avatars = document.querySelectorAll("#select-avatar-popup .avatar")
var selectAvatarPopup = $("#select-avatar-popup")
var handlerToAvatarPlayer
var startGameButton = document.querySelector(".start-game")
var pawnColors = ["#00a3e0", "#e61616", "#ffea2a", "#048c7f", "#da1984", "#f2ac29"]


window.addEventListener('load', () => {

    /*-------------------- 
    Start Game Functions
    --------------------*/

    addPlayerButton.addEventListener("click", addPlayer)  //Add new player field to the list event

    avatarsList.forEach(a => {                            //Change modal to change avatar player event              
        a.addEventListener("click", showAvatarList)
    })

    avatars.forEach(a => {                                //Change avatar player event
        a.addEventListener("click", setAvatar)
    })

    startGameButton.addEventListener("click", startGame)


    function addPlayer() {                               //Function to add new field to player list
        var playerContainer = document.createElement("div")
        var playerAvatar = document.createElement("div")
        var playerData = document.createElement("div")
        var label = document.createElement("label")
        var input = `<input type="text" name="player-name" class="player-name" id="player-${countPlayers}-name">`

        playerContainer.classList.add("player-container", `player-${countPlayers}`)
        playerAvatar.classList.add("player-avatar")
        playerAvatar.dataset.avatar = `/assets/img/avatar-${countPlayers}.jpg`
        playerAvatar.dataset.color = `${pawnColors[0]}`
        playerData.classList.add("player-data")
        label.innerHTML = "Name:"
        playerData.append(label)
        playerData.innerHTML += input
        playerContainer.append(playerAvatar)
        playerContainer.append(playerData)

        if (countPlayers <= 6) {
            document.querySelector(".players").append(playerContainer)
            countPlayers++
            playerContainer.children[0].addEventListener("click", showAvatarList)
        }
        else {
            $('#alert-max-players').modal('show')
        }
    }

    function showAvatarList() {                         //Function to show list avatars
        handlerToAvatarPlayer = this
        selectAvatarPopup.modal('show')
    }

    function setAvatar() {                              //Function to set selected avatar
        var selected = document.querySelector(".selected")
        if (selected != null)
            selected.classList.remove("selected")
        this.classList.add("selected")
        handlerToAvatarPlayer.style.backgroundImage = 'url("' + this.dataset.url + '")'
        handlerToAvatarPlayer.dataset.avatar = this.dataset.url
    }

    function startGame() {                               //Config and start game
        var handler = document.querySelectorAll(".player-container")
        var data = new Array()
        var count = 0
        var kamil = "kami"

        var results = new Array();

        var emp1 = { "ID": "12", "Name": "Manas" };
        results.push(emp1);

        var emp2 = { "ID": "2", "Name": "Tester" };
        results.push(emp2); 
        var postData = { empList: results };
  

            $.ajax({
                url: "/EuroBusiness/StartGame",
                data: ' { name: "Kamil" }',
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
              
                success: function (response) {
                    console.log(response)
                    window.location = "/EuroBusiness/EuroBusiness"
                },
                error: function (response) {
                    console.log("Coś poszło nie tak" + response)
                }
            })
       

        console.log(postData)
    }

    function validate(a) {
        var result
        for (const b of a) {
            if (b.children[1].children[1].value && b.children[1].children[1].value.trim())
                result = true
            else {
                result = false
                break
            }
        }
        return result
    }
})