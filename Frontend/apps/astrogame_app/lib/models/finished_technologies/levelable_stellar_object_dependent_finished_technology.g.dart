// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'levelable_stellar_object_dependent_finished_technology.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LevelableStellarObjectDependentFinishedTechnology
    _$LevelableStellarObjectDependentFinishedTechnologyFromJson(
        Map<String, dynamic> json) {
  return LevelableStellarObjectDependentFinishedTechnology()
    ..level = json['level'] as int
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String)
    ..colonizedStellarObjectId = const GuidConverter()
        .fromJson(json['colonizedStellarObjectId'] as String);
}

Map<String, dynamic> _$LevelableStellarObjectDependentFinishedTechnologyToJson(
        LevelableStellarObjectDependentFinishedTechnology instance) =>
    <String, dynamic>{
      'level': instance.level,
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'playerId': const GuidConverter().toJson(instance.playerId),
      'colonizedStellarObjectId':
          const GuidConverter().toJson(instance.colonizedStellarObjectId),
    };
