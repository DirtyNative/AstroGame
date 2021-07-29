import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:json_annotation/json_annotation.dart';

part 'levelable_condition.g.dart';

@GuidConverter()
@JsonSerializable()
class LevelableCondition extends Condition {
  late int neededLevel;

  LevelableCondition();

  factory LevelableCondition.fromJson(Map<String, dynamic> json) =>
      _$LevelableConditionFromJson(json);
  Map<String, dynamic> toJson() => _$LevelableConditionToJson(this);
}
