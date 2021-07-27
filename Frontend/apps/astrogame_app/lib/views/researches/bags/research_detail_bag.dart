import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';

class ResearchDetailBag {
  Research research;
  FinishedTechnology? finishedTechnology;

  ResearchDetailBag(this.research, this.finishedTechnology);
}
