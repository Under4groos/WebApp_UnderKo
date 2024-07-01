


function fetch(url , func ) {
    fetch(url).then(function (response) {
        return response.json();
    }).then(function (data) {
        func(data);
    }).catch(function (err) {
        console.log('Fetch Error :-S', err);
    });
}