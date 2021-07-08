import 'package:astrogame_app/communications/repositories/technology_repository.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/technology_value.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingDetailViewModel extends FutureViewModel {
  TechnologyRepository _technologyRepository;
  ResourceProvider _resourceProvider;
  BuildingImageProvider _buildingImageProvider;

  Building building;
  FinishedTechnology finishedTechnology;

  BuildingDetailViewModel(
    this._technologyRepository,
    this._resourceProvider,
    this._buildingImageProvider,
    @factoryParam this.building,
    @factoryParam this.finishedTechnology,
  );

  List<TechnologyValue> _technologyValues;
  List<TechnologyValue> get technologyValues => _technologyValues;
  set technologyValues(List<TechnologyValue> val) {
    _technologyValues = val;
    notifyListeners();
  }

  List<Resource> _resources;
  List<Resource> get resources => _resources;
  set resources(List<Resource> val) {
    _resources = val;
    notifyListeners();
  }

  ImageProvider _buildingImage;
  ImageProvider get buildingImage => _buildingImage;
  set buildingImage(ImageProvider val) {
    _buildingImage = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    buildingImage = await _fetchImageAsync(building.assetName);
    resources = await _fetchResourcesAsync();
    technologyValues = await _fetchBuildingValues();
  }

  Future<List<Resource>> _fetchResourcesAsync() async {
    return await _resourceProvider.getAsync();
  }

  Future<List<TechnologyValue>> _fetchBuildingValues() async {
    var response = await _technologyRepository.getValuesAsync(
        building.id, finishedTechnology?.level ?? 1, 10);

    if (response.hasError) {
      throw Exception(response.error);
    }

    return response.data;
  }

  Future<ImageProvider> _fetchImageAsync(String assetName) async {
    return await _buildingImageProvider.get(assetName);
  }
}
