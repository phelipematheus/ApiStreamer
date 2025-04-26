using Application.Interfaces;
using Application.ItemPlaylist.ViewModels;
using Application.Playlists.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ItemPlaylist.Queries;

public sealed record GetItemPlaylistByConteudoIdQuery(
    int ConteudoId
) : IQuery<IEnumerable<PlaylistViewModel>>;
