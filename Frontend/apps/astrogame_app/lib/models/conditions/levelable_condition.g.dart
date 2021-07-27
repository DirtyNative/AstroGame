// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'levelable_condition.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LevelableCondition _$LevelableConditionFromJson(Map<String, dynamic> json) {
  return LevelableCondition()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..neededTechnologyId =
        const GuidConverter().fromJson(json['neededTechnologyId'] as String)
    ..neededLevel = json['neededLevel'] as int;
}

Map<String, dynamic> _$LevelableConditionToJson(LevelableCondition instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'neededTechnologyId':
          const GuidConverter().toJson(instance.neededTechnologyId),
      'neededLevel': instance.neededLevel,
    };
