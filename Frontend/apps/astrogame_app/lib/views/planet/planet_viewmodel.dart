import 'package:astrogame_app/services/event_service.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:video_player/video_player.dart';

@injectable
class PlanetViewModel extends BaseViewModel {
  EventService _eventService;

  VideoPlayerController controller;

  PlanetViewModel(this._eventService) {
    controller = VideoPlayerController.network(
      //'https://www.sample-videos.com/video123/mp4/720/big_buck_bunny_720p_20mb.mp4')
      'https://localhost:7555/api/v1/video/00BA4493-9221-458F-AC86-05F35E186FA1',
    )..initialize().then((_) {
        // Ensure the first frame is shown after the video is initialized, even before the play button has been pressed.
        notifyListeners();
      });

    controller.setVolume(0);
    controller.setLooping(true);
    //VideoPlayerController.network('https://localhost:7555/api/v1/video');
  }

  void play() {
    controller.play();
  }
}
