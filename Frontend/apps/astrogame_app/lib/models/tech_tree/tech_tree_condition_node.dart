import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/conditions/levelable_condition.dart';
import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';

class TechTreeConditionNode {
  Technology technology;
  FinishedTechnology finishedTechnology;
  Condition condition;

  TechTreeConditionNode(
    this.technology,
    this.finishedTechnology,
    this.condition,
  );
}
