import 'package:astrogame_app/communications/repositories/stellar_object_repository.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ConstructionViewModel extends FutureViewModel {
  StellarObjectRepository _stellarObjectRepository;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  BuildingConstruction _buildingConstruction;
  BuildingConstruction get buildingConstruction => _buildingConstruction;
  set buildingConstruction(BuildingConstruction val) {
    _buildingConstruction = val;
    notifyListeners();
  }

  StellarObject _stellarObject;
  StellarObject get stellarObject => _stellarObject;
  set stellarObject(StellarObject val) {
    _stellarObject = val;
    notifyListeners();
  }

  ConstructionViewModel(
    this._stellarObjectRepository,
    this._selectedColonizedStellarObjectProvider,
    @factoryParam this._buildingConstruction,
  );

  Future<ImageProvider> getCurrentStellarObjectImageAsync() async {
    var stellarObjectId = _selectedColonizedStellarObjectProvider
        .getSelectedObject()
        .stellarObjectId;

    var response = await _stellarObjectRepository.getImageAsync(
      stellarObjectId: stellarObjectId,
    );

    if (response.hasError) {
      throw Exception('Failed to load stellar object image $stellarObjectId');
    }

    return response.data;
  }

  Future<StellarObject> _fetchStellarObject() async {
    var stellarObjectId = _selectedColonizedStellarObjectProvider
        .getSelectedObject()
        .stellarObjectId;

    var response = await _stellarObjectRepository.getAsync(stellarObjectId);

    if (response.hasError) {
      throw new Exception(response.error);
    }

    return response.data;
  }

  @override
  Future futureToRun() async {
    stellarObject = await _fetchStellarObject();
  }
}
