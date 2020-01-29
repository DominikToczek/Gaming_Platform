window.addEventListener('load', () => {

    var players = localStorage.getItem('players')
    players = JSON.parse(players)

    $.ajax({
        type: "POST",
        data: { playersData: players },
        url: "/EuroBusiness/StartGame",
        success: function (response) {
            console.log(response)                    
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response)
        }
    })


    var a = {
        numer_pola: numer pola na którym stoi gracz
    }
})