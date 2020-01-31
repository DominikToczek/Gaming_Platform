
window.addEventListener('load', () => {
    var players = localStorage.getItem('players')
    var playersDataFromServer
    var playersHandle
    var pawnHandle
    var diceHandle
    var spacesBoard
    var throwDiceButton = document.querySelector("#throw-dice-button")

    configGame()
    players = JSON.parse(players)
    startGame(players)

    throwDiceButton.addEventListener("click", throwDice)
})

function startGame(a) {
    $.ajax({
        type: "POST",
        data: { playersData: a },
        url: "/EuroBusiness/StartGame",
        success: function (response) {
            response.forEach(a => {
                addPlayer(a)
            })

            playersDataFromServer = response
            configGame()
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response.error)
        }
    })
}

function addPlayer(a) {
    var players = document.querySelector(".player-container")
    var playerContainer = document.createElement("div")
    var playerAvatar = document.createElement("div")
    var playerData = document.createElement("div")
    var playerName = document.createElement("div")
    var playerMoney = document.createElement("div")

    playerContainer.classList.add("player", `player-${a.pawn.number}`)
    playerAvatar.classList.add("player-avatar")
    playerAvatar.style.backgroundImage = `url(${a.avatar})`
    playerData.classList.add("player-data")
    playerName.classList.add("player-name")
    playerMoney.classList.add("player-money")

    playerName.innerHTML = a.name
    playerMoney.innerHTML = a.money
    playerData.appendChild(playerName)
    playerData.appendChild(playerMoney)
    playerContainer.appendChild(playerAvatar)
    playerContainer.appendChild(playerData)
    players.appendChild(playerContainer)

    addPawn(a.pawn.color, a.pawn.number)
}

function addPawn(c, b) {
    var pawnContainer = document.querySelector(".pawn-container")
    var pawn = document.createElement("div")
    var pawnPosition = [
        [30, 10],
        [30, 30],
        [30, 50],
        [55, 50],
        [55, 30],
        [55, 10]
    ]

    pawn.classList.add("pawn", `pawn--${b}`)
    pawn.style.backgroundColor = `${c}`
    pawn.dataset.pawnNumber = b
    pawn.dataset.currentPosition = 1
    pawn.dataset.currentPositionX = pawnPosition[b - 1][0]
    pawn.dataset.currentPositionY = pawnPosition[b - 1][1]
    pawnContainer.appendChild(pawn)
}

function movePawn(pawn, space) {
    var smallSpaceWidth = document.querySelector("#space-2").offsetWidth
    var moveX = 0
    var moveY = 0
    var rotateX = 0
    var rotateY = 0
    var scale = document.querySelector(".board").offsetWidth / 650
    var currentPosition = pawn.dataset.currentPosition

    if (pawn.dataset.pawnNumber == 1) {
        rotateX = [40 * scale, -20 * scale, 45 * scale, 30 * scale]
        rotateY = [20 * scale, 45 * scale, -20 * scale, 10 * scale]
    }
    if (pawn.dataset.pawnNumber == 2) {
        rotateX = [20 * scale, 0 * scale, 25 * scale, 30 * scale]
        rotateY = [0 * scale, 25 * scale, 0 * scale, 30 * scale]
    }
    if (pawn.dataset.pawnNumber == 3) {
        rotateX = [0 * scale, 20 * scale, 5 * scale, 30 * scale]
        rotateY = [-20 * scale, 5 * scale, 20 * scale, 50 * scale]
    }
    if (pawn.dataset.pawnNumber == 4) {
        rotateX = [-25 * scale, -5 * scale, 20 * scale, 55 * scale]
        rotateY = [5 * scale, 20 * scale, -45 * scale, 50 * scale]
    }
    if (pawn.dataset.pawnNumber == 5) {
        rotateX = [-5 * scale, -25 * scale, 0 * scale, 55 * scale]
        rotateY = [25 * scale, 0 * scale, -25 * scale, 30 * scale]
    }
    if (pawn.dataset.pawnNumber == 6) {
        rotateX = [15 * scale, -45 * scale, -20 * scale, 55 * scale]
        rotateY = [45 * scale, -20 * scale, -5 * scale, 10 * scale]
    }

    //move the pawn according to the sections
    if (space < 12) {
        moveSection1(space)
    }
    else if (space < 22) {
        let promise = new Promise(() => moveSection1(11)).then(setTimeout(() => {
            moveSection2(space)
        }, 2000))
    }
    else if (space < 32) {
        let promise = new Promise(() => moveSection1(11)).then(setTimeout(() => {
            moveSection2(21)
        }, 2000)).then(setTimeout(() => {
            moveSection3(space)
        }, 4000))
    }
    else if (space < 41) {
        let promise = new Promise(() => moveSection1(11)).then(setTimeout(() => {
            moveSection2(21)
        }, 2000)).then(setTimeout(() => {
            moveSection3(31)
        }, 4000)).then(setTimeout(() => {
            moveSection4(space)
        }, 6000))
    }


    function moveSection1(a) {
        switch (a) {
            case 11:
                moveX += smallSpaceWidth / 5 * 8 + rotateX[0]
                moveY += rotateY[0]
            case 10:
                moveX += smallSpaceWidth
                moveY += 0
            case 9:
                moveX += smallSpaceWidth
                moveY += 0
            case 8:
                moveX += smallSpaceWidth
                moveY += 0
            case 7:
                moveX += smallSpaceWidth
                moveY += 0
            case 6:
                moveX += smallSpaceWidth
                moveY += 0
            case 5:
                moveX += smallSpaceWidth
                moveY += 0
            case 4:
                moveX += smallSpaceWidth
                moveY += 0
            case 3:
                moveX += smallSpaceWidth
                moveY += 0
            case 2:
                moveX += smallSpaceWidth / 2 * 3
                moveY += 0
            case 1:
                moveX += rotateX[3]
                moveY += rotateY[3]
                break
        }
        pawn.style.right = moveX
        pawn.style.bottom = moveY
        pawn.dataset.currentPosition = a
    }

    function moveSection2(a) {
        switch (a) {
            case 21:
                moveX += 0 + rotateX[1]
                moveY += smallSpaceWidth / 2 * 3 + rotateY[1]
            case 20:
                moveX += 0
                moveY += smallSpaceWidth
            case 19:
                moveX += 0
                moveY += smallSpaceWidth
            case 18:
                moveX += 0
                moveY += smallSpaceWidth
            case 17:
                moveX += 0
                moveY += smallSpaceWidth
            case 16:
                moveX += 0
                moveY += smallSpaceWidth
            case 15:
                moveX += 0
                moveY += smallSpaceWidth
            case 14:
                moveX += 0
                moveY += smallSpaceWidth
            case 13:
                moveX += 0
                moveY += smallSpaceWidth
            case 12:
                moveX += 0
                moveY += smallSpaceWidth / 2 * 3
        }
        pawn.style.right = moveX
        pawn.style.bottom = moveY
        pawn.dataset.currentPosition = a
    }

    function moveSection3(a) {
        switch (a) {
            case 31:
                moveX -= smallSpaceWidth / 2 * 3 + rotateX[2]
                moveY += 0 + rotateY[2]
            case 30:
                moveX -= smallSpaceWidth
                moveY += 0
            case 29:
                moveX -= smallSpaceWidth
                moveY += 0
            case 28:
                moveX -= smallSpaceWidth
                moveY += 0
            case 27:
                moveX -= smallSpaceWidth
                moveY += 0
            case 26:
                moveX -= smallSpaceWidth
                moveY += 0
            case 25:
                moveX -= smallSpaceWidth
                moveY += 0
            case 24:
                moveX -= smallSpaceWidth
                moveY += 0
            case 23:
                moveX -= smallSpaceWidth
                moveY += 0
            case 22:
                moveX -= smallSpaceWidth / 2 * 3
                moveY += 0
        }

        pawn.style.right = moveX
        pawn.style.bottom = moveY
        pawn.dataset.currentPosition = a
    }

    function moveSection4(a) {
        switch (a) {
            case 40:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 39:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 38:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 37:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 36:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 35:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 34:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 33:
                moveX -= 0
                moveY -= smallSpaceWidth
            case 32:
                moveX -= 0
                moveY -= smallSpaceWidth / 2 * 3
        }

        pawn.style.right = moveX
        pawn.style.bottom = moveY
        pawn.dataset.currentPosition = a
    }
}

function loadWelcomeScreen() {
    //dopisać wyskakujące okienko na początku gry
}

function configGame() {
    playersHandle = document.querySelectorAll(".player")
    pawnHandle = document.querySelectorAll(".pawn")
    diceHandle = document.querySelector(".dice")
    spacesBoard = document.querySelectorAll(".space")


    console.log(playersHandle)
    console.log(pawnHandle)
    console.log(diceHandle)
    console.log(spacesBoard)
}


function throwDice() {
    $.ajax({
        type: "POST",
        url: "/EuroBusiness/DiceThrow",
        success: function (response) {
            response.forEach(a => {
                console.log(response)
            })
        },
        error: function (response) {
            console.log("Coś poszło nie tak z rzutem kostką" + response)
        }
    })

    console.log("fdsafasdfasd")
}