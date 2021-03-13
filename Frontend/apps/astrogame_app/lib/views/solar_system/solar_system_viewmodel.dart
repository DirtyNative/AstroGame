import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/views/solar_system/events/solar_system_loaded_event.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class SolarSystemViewModel extends BaseViewModel {
  EventService _eventService;

  SolarSystem _solarSystem;
  SolarSystem get solarSystem => _solarSystem;
  set solarSystem(SolarSystem val) {
    _solarSystem = val;
    notifyListeners();
  }

  SolarSystemViewModel(this._eventService) {
    _eventService.on<SolarSystemLoadedEvent>().listen((event) {
      solarSystem = event.solarSystem;
    });
  }
}
