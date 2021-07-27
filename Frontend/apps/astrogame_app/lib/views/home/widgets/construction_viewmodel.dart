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

  BuildingConstruction? _buildingConstruction;
  BuildingConstruction? get buildingConstruction => _buildingConstruction;
  set buildingConstruction(BuildingConstruction? val) {
    _buildingConstruction = val;
    notifyListeners();
  }

  late StellarObject _stellarObject;
  StellarObject get stellarObject => _stellarObject;
  set stellarObject(StellarObject val) {
    _stellarObject = val;
    notifyListeners();
  }

  ConstructionViewModel(
    this._stellarObjectRepository,
    this._selectedColonizedStellarObjectProvider,
    @factoryParam this._buildingConstruction,
  ) : assert(_buildingConstruction != null);

  Future<ImageProvider> getCurrentStellarObjectImageAsync() async {
    var selectedStellarObject =
        _selectedColonizedStellarObjectProvider.getSelectedObject();

// TODO: Get this from Provider
    var response = await _stellarObjectRepository.getImageAsync(
      selectedStellarObject!.stellarObjectId,
    );

    if (response.hasError) {
      throw Exception(
          'Failed to load stellar object image $selectedStellarObject.stellarObjectId');
    }

    return response.data!;
  }

  Future<StellarObject> _fetchStellarObject() async {
    var selectedStellarObject =
        _selectedColonizedStellarObjectProvider.getSelectedObject();

    var response = await _stellarObjectRepository
        .getAsync(selectedStellarObject!.stellarObjectId);

    if (response.hasError) {
      throw new Exception(response.error);
    }

    return response.data!;
  }

  @override
  Future futureToRun() async {
    stellarObject = await _fetchStellarObject();
  }
}
