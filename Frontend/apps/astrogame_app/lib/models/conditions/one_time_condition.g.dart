// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'one_time_condition.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OneTimeCondition _$OneTimeConditionFromJson(Map<String, dynamic> json) {
  return OneTimeCondition()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..neededTechnologyId =
        const GuidConverter().fromJson(json['neededTechnologyId'] as String);
}

Map<String, dynamic> _$OneTimeConditionToJson(OneTimeCondition instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'neededTechnologyId':
          const GuidConverter().toJson(instance.neededTechnologyId),
    };
