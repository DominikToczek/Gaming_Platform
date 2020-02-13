//Poprawić funkcje które korzystają z ceny domków
class field {
    constructor(fieldID, name, fieldCost) {
        this.name = name
        this.fieldCost = fieldCost
        this.handle = document.querySelector(`#space-${fieldID}`)
    }
}

let playersDataFromServer
let playersHandle
let pawnHandle
let diceHandle
let Board = []
let playerTurn
let throwDiceButton = document.querySelector("#throw-dice-button")
let responceFromServer
let responceOnStartTurn = {
    idPlayer: 1,//int
    numberOfMeshes: 2, //int
    currentPlayerField: 25, //int
    actionField: true,//true or false
    actionNumber: 2,//int
    ocupation: true,//true or false
    ocupationByPlayerTurn: true, //true or false
    IDOfOccupationFieldPlayer: 2,//int
    payingForVisitOcupationField: 2,//int
    canBuyHotel: true,//true or false
    IDOfNextPlayer: 2,//int
    bankrupt: true, //true or false
    houseCost: 20,
    hotelCost: 500
}


window.addEventListener('load', () => {
    let players = localStorage.getItem('players')
    let bankruptButton = document.querySelector(".bankrut-button")
    let comunicateModalButton = document.querySelector("#comunication-modal-close-button")
    let buyHouseModalButtonYes = document.querySelector(".buy-field-modal .buy-field-modal-button-yes")
    let buyHouseModalButtonNo = document.querySelector(".buy-field-modal .buy-field-modal-button-no")
    let buyHotelModalButtonYes = document.querySelector(".buy-hotel-modal .buy-hotel-modal-button-yes")
    let buyHotelModalButtonNo = document.querySelector(".buy-hotel-modal .buy-hotel-modal-button-no")
    let buyFieldModalButtonYes = document.querySelector(".buy-house-modal .buy-house-modal-button-yes")
    let buyFieldModalButtonNo = document.querySelector(".buy-house-modal .buy-house-modal-button-no")

    players = JSON.parse(players)
    startGame(players)

    playerTurn = document.querySelector(".player-turn")

    throwDiceButton.addEventListener("click", throwDice)
    bankruptButton.addEventListener("click", playerIsBankrupt)
    comunicateModalButton.addEventListener("click", nextTurn)
    buyHouseModalButtonYes.addEventListener("click", buyHouse)
    buyHouseModalButtonNo.addEventListener("click", nextTurn)
    buyHotelModalButtonYes.addEventListener("click", buyHotel)
    buyHotelModalButtonNo.addEventListener("click", nextTurn)
    buyFieldModalButtonYes.addEventListener("click", buyField)
    buyFieldModalButtonNo.addEventListener("click", nextTurn)
})

function startGame(a) {
    $.ajax({
        type: "POST",
        data: { playersData: a },
        url: "/EuroBusiness/StartGame",
        success: function (response) {
            response.players.forEach(a => {
                addPlayer(a)
            })

            let count = 0;
            response.fields.forEach(b => {
                let a = new field(count, b.name, b.fieldCost)

                Board.push(a)
                count++
            })


            playersDataFromServer = response.players
            configGame()

            console.log(response)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response.error)
        }
    })
}

function configGame() {
    playersHandle = document.querySelectorAll(".player")
    playersHandle[0].setAttribute("id", "player--active")
    pawnHandle = document.querySelectorAll(".pawn")
    diceHandle = document.querySelector(".dice")
}

function addPlayer(a) {
    let players = document.querySelector(".player-container")
    let playerContainer = document.createElement("div")
    let playerAvatar = document.createElement("div")
    let playerData = document.createElement("div")
    let playerName = document.createElement("div")
    let playerMoney = document.createElement("div")

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
    let pawnContainer = document.querySelector(".pawn-container")
    let pawn = document.createElement("div")
    let pawnPosition = [
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
    let smallSpaceWidth = document.querySelector("#space-2").offsetWidth
    let moveX = 0
    let moveY = 0
    let rotateX = 0
    let rotateY = 0
    let scale = document.querySelector(".board").offsetWidth / 650

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


function throwDice() {
    $.ajax({
        type: "POST",
        url: "/EuroBusiness/DiceThrow",
        success: function (a) {
            responceFromServer = JSON.parse(JSON.stringify(a))
            turnStart(responceFromServer)
        },
        error: function (a) {
            console.log("Coś poszło nie tak z rzutem kostką" + a)
        }
    })
}


///////////Comunicate functions////////////////
///////////////////////////////////////////////

function showComunicate(title, photo, message) {
    let titleHandle = document.querySelector(".comunication-modal .modal-title")
    let bodyHandle = document.querySelector(".comunication-modal .modal-body .modal-message")
    let photoHandle = document.querySelector(".comunication-modal .modal-body .modal-body-photo")


    photoHandle.style.backgroundImage = `url(${photo})`
    titleHandle.innerHTML = title
    bodyHandle.innerHTML = message
    $('.comunication-modal').modal('show')
}

function showBankrutComunicate() {
    $('.bankrut-modal').modal('show')
}

function showBuyFieldComunicate() {
    let titleHandle = document.querySelector(".buy-field-modal .modal-title")
    let messageHandle = document.querySelector(".buy-field-modal .modal-message")

    titleHandle.innerHTML = Board[responceOnStartTurn.currentPlayerField - 1].name
    messageHandle.innerHTML = `Price: ${Board[responceOnStartTurn.currentPlayerField - 1].fieldCost} <br> You want buy this field?`

    $('.buy-field-modal').modal('show')
}

function showBuyHouseComunicate() {
    let titleHandle = document.querySelector(".buy-field-modal .modal-title")
    let messageHandle = document.querySelector(".buy-field-modal .modal-message")

    titleHandle.innerHTML = Board[responceOnStartTurn.currentPlayerField - 1].name
    messageHandle.innerHTML = `Price: ${Board[responceOnStartTurn.currentPlayerField - 1].fieldCost} <br> You want buy new house on this field?`

    $('.buy-field-modal').modal('show')
}

function showBuyHotelComunicate() {
    let titleHandle = document.querySelector(".buy-field-modal .modal-title")
    let messageHandle = document.querySelector(".buy-field-modal .modal-message")

    titleHandle.innerHTML = Board[responceOnStartTurn.currentPlayerField - 1].name
    messageHandle.innerHTML = `Price: ${Board[responceOnStartTurn.currentPlayerField - 1].fieldCost} <br> You want buy hotel on this field?`

    $('.buy-field-modal').modal('show')
}

//////////////*************TURN START FUNCTION*********************///////////////
/********************************************************************************/


function turnStart(responce) {
    diceHandle.style.display = "block"
    diceHandle.classList.add(`throw-${responceOnStartTurn.numberOfMeshes}`)
    movePawn(pawnHandle[responceOnStartTurn.idPlayer - 1], responceOnStartTurn.currentPlayerField)
    console.log("turn start:" + responce)
    if (responce.RodzajPola) {
        startAction(responce) //funkcja do dopisania
    }
    else {
        if (responceOnStartTurn.ocupation) {
            if (responceOnStartTurn.ocupationByPlayerTurn) {  //okupowany przez gracza do którego należy tura
                if (responceOnStartTurn.canBuyHotel) {      //może kupić hotel tj. ma 4 domki
                    if (playersDataFromServer[responceFromServer.idPlayer - 1].money >= responceOnStartTurn.hotelCost) { //jeżeli stać cię na hotel
                        showBuyHotelComunicate()
                    }
                    else {   //zbyt mało pieniędzy aby kupić hotel
                        let title = "To little money"
                        let photo = ""  //dodać jakieś zdjęcie jak będzie gotowe
                        let message = "You don't have enough money to buy a hotel on this field"


                        showComunicate(title, photo, message)
                    }
                }
                else {      //nie możesz kupić hotelu to może domek
                    if (playersDataFromServer[responceFromServer.IDPlayer - 1].money >= responceOnStartTurn.houseCost) { //jeżeli stać cię na domek
                        showBuyHouseComunicate()
                    }
                    else {
                        let title = "To little money"
                        let photo = ""  //dodać jakieś zdjęcie jak będzie gotowe
                        let message = "You don't have enough money to buy a house on this field"


                        showComunicate(title, photo, message)
                    }

                }
            }
            else {          //okupowany przez innego gracza
                if (responceOnStartTurn.bankrupt) {
                    showBankrutComunicate()
                }
                else {
                    let title = "Fee for stop"
                    let photo = ""  //dodać zdjęcie gdy będzie gotowe
                    let message = `This field belongs to ${playersDataFromServer[responceOnStartTurn.IDOfOccupationFieldPlayer].name}. You must pay a ${responceOnStartTurn.payingForVisitOcupationField} fee!`
                    showComunicate(title, photo, message)
                }
            }
        }

        else {      //jeśli nie okupowany
            if (Board[responceOnStartTurn.currentPlayerField].fieldCost <= playersDataFromServer.money) {   //jeśli stać na zakup pola
                showBuyFieldComunicate()
            }
            else {      //jeśli nie stać na zakup pola
                let title = "Too little money"
                let photo = ""  //dodać zdjęcie gdy będzie gotowe
                let message = `You don't have enough money to buy this field`
                showComunicate(title, photo, message)
            }
        }
    }

}

///////////Actions functions////////////////
///////////////////////////////////////////////

function startAction(a) {
    console.log(a)
}

function playerIsBankrupt() {
    playersHandle[responceOnStartTurn.IDPlayer - 1].remove()
}

function nextTurn() {
    playersHandle[responceOnStartTurn.IDPlayer - 1].removeAttribute("id", "player--active")
    playersHandle[responceOnStartTurn.IDOfNextPlayer - 1].setAttribute("id", "player--active")

    playerTurn.innerHTML = `Turn ${playersDataFromServer[responceOnStartTurn.IDOfNextPlayer - 1].name}`

    $.ajax({
        type: "POST",
        url: "/EuroBusiness/NextTurn",
        success: function (a) {
            
        },
        error: function (a) {
            console.log("Coś poszło nie tak przejściem do następnej tury" + a)
        }
    })
}

function buyField() {
    let a = {
        IDplayer: responceOnStartTurn.IDPlayer,
        numer_pola: responceOnStartTurn.currentPlayerField
    }

    $.ajax({
        type: "POST",
        data: { buyFieldData: a },
        url: "/EuroBusiness/BuyField",
        success: function (responce) {
            let title = Board[responceOnStartTurn.currentPlayerField].name
            let photo = ""  //dodać jakieś zdjęcie do tego  /assets/img/buyFiled.jpg
            let message = `You have bought ${Board[responceOnStartTurn.currentPlayerField].name}`
            playersHandle[responceOnStartTurn.IDPlayer].children[1].children[1].innerHTML = responce.money
            playersDataFromServer[responceOnStartTurn.IDPlayer].money = responce.money

            showComunicate(title, photo, message)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response.error)
        }
    })
}

function buyHouse() {
    let a = {
        IDplayer: responceOnStartTurn.IDPlayer,
        numer_pola: responceOnStartTurn.currentPlayerField
    }

    $.ajax({
        type: "POST",
        data: { buyFieldData: a },
        url: "/EuroBusiness/BuyHouse",
        success: function (responce) {
            let title = Board[responceOnStartTurn.currentPlayerField].name
            let photo = ""  //dodać jakieś zdjęcie do tego  /assets/img/buyFiled.jpg
            let message = `You have bought new house`
            playersHandle[responceOnStartTurn.IDPlayer].children[1].children[1].innerHTML = responce.money
            playersDataFromServer[responceOnStartTurn.IDPlayer].money = responce.money
            addBuildToField(true)

            showComunicate(title, photo, message)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response.error)
        }
    })
}

function buyHotel() {
    let a = {
        IDplayer: responceOnStartTurn.IDPlayer,
        numer_pola: responceOnStartTurn.currentPlayerField
    }

    $.ajax({
        type: "POST",
        data: { buyFieldData: a },
        url: "/EuroBusiness/BuyHotel",
        success: function (responce) {
            let title = Board[responceOnStartTurn.currentPlayerField].name
            let photo = ""  //dodać jakieś zdjęcie do tego  /assets/img/buyFiled.jpg
            let message = `You have bought new hotel`
            playersHandle[responceOnStartTurn.IDPlayer].children[1].children[1].innerHTML = responce.money

            playersDataFromServer[responceOnStartTurn.IDPlayer].money = responce.money
            addBuildToField(false)

            showComunicate(title, photo, message)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response.error)
        }
    })
}

//true = house false = hotel

function addBuildToField(a) {
    let field = Board[responceOnStartTurn.currentPlayerField - 1].handle

    if (a) {
        let container = createElement("div")
        let house = '<i class="fas fa-home"></i>'
        container.classList.add("house")
        container.appendChild(house)

        field.appendChild(container)
    }

    else {
        let containerHotel = createElement("div")
        let hotel = '<i class="fas fa-hotel"></i>'

        field.childNodes.forEach(e => e.remove())
        containerHotel.appendChild(hotel)

        field.appendChild(containerHotel)
    }
}

