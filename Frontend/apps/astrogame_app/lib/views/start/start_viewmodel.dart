import 'package:astrogame_app/executers/fetch_solar_system_executer.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/views/solar_system/events/solar_system_loaded_event.dart';
import 'package:flutter/cupertino.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class StartViewModel extends BaseViewModel {
  FetchSolarSystemExecuter _fetchSolarSystemExecuter;
  EventService _eventService;

  TextEditingController solarSystemNumberController;

  StartViewModel(this._fetchSolarSystemExecuter, this._eventService) {
    solarSystemNumberController = new TextEditingController();
  }

  Future loadSolarSystemAsync() async {
    if (solarSystemNumberController.text == null ||
        solarSystemNumberController.text.isEmpty) {
      return null;
    }

    int solarSystemNumber = int.parse(solarSystemNumberController.text);

    var response = await _fetchSolarSystemExecuter
        .fetchSolarSystemByNumberAsync(solarSystemNumber);

    if (response.success == false) {
      return;
    }

    _eventService.fire(new SolarSystemLoadedEvent(response.data));
  }

  Future decrement() async {
    await changeSystemNumber(-1);
  }

  Future increment() async {
    await changeSystemNumber(1);
  }

  Future changeSystemNumber(int step) async {
    int number = 1;

    if (solarSystemNumberController.text == null ||
        solarSystemNumberController.text.isEmpty) {
    } else {
      number = int.parse(solarSystemNumberController.text);
      number += step;
    }

    if (number < 1) {
      number = 1;
    }

    solarSystemNumberController.text = number.toString();

    await loadSolarSystemAsync();
  }

  /*Future<SolarSystem> _fetchSolarSystem() {
    if (solarSystemNumberController.text == null ||
        solarSystemNumberController.text.isEmpty) {
      return null;
    }

    return _solarSystemRepository.getBySystemNumberRecursiveAsync(
        int.parse(solarSystemNumberController.text));
  } */
}
