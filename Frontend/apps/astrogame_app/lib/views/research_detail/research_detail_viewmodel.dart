import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ResearchDetailViewModel extends FutureViewModel {
  ResearchImageProvider _researchImageProvider;

  Research research;
  FinishedTechnology finishedTechnology;

  ResearchDetailViewModel(
    this._researchImageProvider,
    @factoryParam this.research,
    @factoryParam this.finishedTechnology,
  );

  ImageProvider _researchImage;
  ImageProvider get researchImage => _researchImage;
  set researchImage(ImageProvider val) {
    _researchImage = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    researchImage = await _fetchImageAsync(research.assetName);
  }

  Future<ImageProvider> _fetchImageAsync(String assetName) async {
    return await _researchImageProvider.get(assetName);
  }
}
