import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:json_annotation/json_annotation.dart';

part 'one_time_condition.g.dart';

@GuidConverter()
@JsonSerializable()
class OneTimeCondition extends Condition {
  OneTimeCondition();

  factory OneTimeCondition.fromJson(Map<String, dynamic> json) =>
      _$OneTimeConditionFromJson(json);
  Map<String, dynamic> toJson() => _$OneTimeConditionToJson(this);
}
