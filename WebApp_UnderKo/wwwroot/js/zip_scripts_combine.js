
function GitHubDownloadZipLastArchive(url) {
    fetch(url)
        .then((response) => response.json())
        .then((commits) => {
            var link_download_zip = commits[0]["assets"][0]["browser_download_url"];
            console.log(link_download_zip)
            return 
        });
}

$(document).ready(function () {


    var images_ = document.getElementById('li_images');
    
    var vv_ = document.getElementById('modal_image');

    console.log(images_);
    console.log(vv_);
    if (images_ && vv_) {

        var items = images_.children;
        for (var i = 0; i < items.length; i++) {
            var item_ = items[i]
            if (item_)
                item_.addEventListener('click', function (e) {
                    vv_.src = e.target.src
                });
        }
    }

    // console.log(GitHubDownloadZipLastArchive('https://api.github.com/repos/Under4groos/SmdCompile.View/releases'))
});


