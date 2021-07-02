import 'package:astrogame_app/communications/converters/condition_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/technology_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:flutter_guid/flutter_guid.dart';

@GuidConverter()
abstract class Technology {
  Guid id;
  List<Condition> neededConditions;
  List<Condition> conditionFor;

  Technology();

  factory Technology.fromJson(Map<String, dynamic> json) =>
      TechnologyConverter().fromJson(json);

  Map<String, dynamic> toJson() => TechnologyConverter().toJson(this);
}
