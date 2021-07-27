import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';

class ShowTechTreeViewBag {
  Technology technology;
  FinishedTechnology? finishedTechnology;

  ShowTechTreeViewBag(this.technology, this.finishedTechnology);
}
