   const player = new Plyr('#player', {
        controls: ['play', 'progress', 'current-time', 'mute', 'volume', 'fullscreen'],
    seekTime: 10,
    keyboard: {
        focused: true,
    global: true,
        },
    tooltips: {
        controls: true,
    seek: true,
        },
    });
