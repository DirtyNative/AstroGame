// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'player.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Player _$PlayerFromJson(Map<String, dynamic> json) {
  return Player()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..username = json['username'] as String
    ..playerSpeciesId =
        const GuidConverter().fromJson(json['playerSpeciesId'] as String)
    ..colonizedObjects = (json['colonizedObjects'] as List<dynamic>)
        .map((e) => ColonizedStellarObject.fromJson(e as Map<String, dynamic>))
        .toList()
    ..playerSpecies = json['playerSpecies'] == null
        ? null
        : PlayerSpecies.fromJson(json['playerSpecies'] as Map<String, dynamic>);
}

Map<String, dynamic> _$PlayerToJson(Player instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'username': instance.username,
      'playerSpeciesId': const GuidConverter().toJson(instance.playerSpeciesId),
      'colonizedObjects': instance.colonizedObjects,
      'playerSpecies': instance.playerSpecies,
    };
