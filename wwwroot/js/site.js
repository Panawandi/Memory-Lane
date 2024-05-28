// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function() {
    const searchInput = document.getElementById('search');
    const videoContainer = document.querySelector('.video-container'); // Use class selector

    searchInput.addEventListener('input', function(event) {
        const searchQuery = event.target.value.trim().toLowerCase();
        const videos = videoContainer.querySelectorAll('.recommendation-box');

        videos.forEach(video => {
            const title = video.querySelector('p').textContent.toLowerCase();
            if (title.includes(searchQuery)) {
                video.style.display = 'block';
            } else {
                video.style.display = 'none';
            }
        });
    });

    // Randomizing home videos

    // Get all the video containers
    const videos = Array.from(videoContainer.children);

    // Shuffle the video containers
    const shuffledVideos = shuffle(videos);

    // Clear the original container
    videoContainer.innerHTML = '';

    // Append the shuffled video containers back to the parent container
    shuffledVideos.forEach(video => {
        videoContainer.appendChild(video);
    });

});

// Function to shuffle an array
const shuffle = array => {
    for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]];
    }
    return array;
};