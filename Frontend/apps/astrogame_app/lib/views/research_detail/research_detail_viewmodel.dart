import 'package:astrogame_app/communications/repositories/research_repository.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/research_value.dart';
import 'package:astrogame_app/models/researches/studied_research.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ResearchDetailViewModel extends FutureViewModel {
  ResearchRepository _researchRepository;
  ResourceProvider _resourceProvider;
  ResearchImageProvider _researchImageProvider;

  Research research;
  StudiedResearch studiedResearch;

  ResearchDetailViewModel(
    this._researchRepository,
    this._resourceProvider,
    this._researchImageProvider,
    @factoryParam this.research,
    @factoryParam this.studiedResearch,
  );

  List<ResearchValue> _researchValues;
  List<ResearchValue> get researchValues => _researchValues;
  set researchValues(List<ResearchValue> val) {
    _researchValues = val;
    notifyListeners();
  }

  List<Resource> _resources;
  List<Resource> get resources => _resources;
  set resources(List<Resource> val) {
    _resources = val;
    notifyListeners();
  }

  ImageProvider _researchImage;
  ImageProvider get researchImage => _researchImage;
  set researchImage(ImageProvider val) {
    _researchImage = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    resources = await _fetchResourcesAsync();
    researchValues = await _fetchResearchValues();
    researchImage = await _fetchImageAsync(research.assetName);
  }

  Future<List<Resource>> _fetchResourcesAsync() async {
    return await _resourceProvider.getAsync();
  }

  Future<List<ResearchValue>> _fetchResearchValues() async {
    var response = await _researchRepository.getValuesAsync(
        research.id, studiedResearch?.level ?? 1, 10);

    if (response.hasError) {
      throw Exception(response.error);
    }

    return response.data;
  }

  Future<ImageProvider> _fetchImageAsync(String assetName) async {
    return await _researchImageProvider.get(assetName);
  }
}
