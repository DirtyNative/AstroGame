// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'one_time_stellar_object_dependent_finished_technology.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OneTimeStellarObjectDependentFinishedTechnology
    _$OneTimeStellarObjectDependentFinishedTechnologyFromJson(
        Map<String, dynamic> json) {
  return OneTimeStellarObjectDependentFinishedTechnology()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String)
    ..level = json['level'] as int
    ..colonizedStellarObjectId = const GuidConverter()
        .fromJson(json['colonizedStellarObjectId'] as String);
}

Map<String, dynamic> _$OneTimeStellarObjectDependentFinishedTechnologyToJson(
        OneTimeStellarObjectDependentFinishedTechnology instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'playerId': const GuidConverter().toJson(instance.playerId),
      'level': instance.level,
      'colonizedStellarObjectId':
          const GuidConverter().toJson(instance.colonizedStellarObjectId),
    };
