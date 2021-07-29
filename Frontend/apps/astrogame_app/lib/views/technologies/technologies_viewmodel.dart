import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

abstract class TechnologiesViewModel extends FutureViewModel {
  PageController controller = PageController();

  late List<Technology> _technologies;
  List<Technology> get technologies => _technologies;
  set technologies(List<Technology> val) {
    _technologies = val;
    notifyListeners();
  }

  int _selectedTabIndex = 0;
  int get selectedTabIndex => _selectedTabIndex;
  set selectedTabIndex(int val) {
    _selectedTabIndex = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    technologies = await fetchTechnologiesAsync();
  }

  Future<List<Technology>> fetchTechnologiesAsync();
}
